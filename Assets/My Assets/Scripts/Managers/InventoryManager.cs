using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Series Followed:
/// Let's make an Inventory System! ErenCode -
/// https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx
/// accessed - 24/12/2023
/// ---------------------
/// Manager Script to manage the players inventory.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private CraftingManager craftingManager;

    [SerializeField] private SlotClass[] startingItems;

    public SlotClass[] items;

    private GameObject[] slots;

    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    private Interactor interactor;
    private IInteractable interactable;
    bool isMovingItem;
    bool isCrafting;
    bool isOverInteractable;
    RaycastHit hit;
    Ray ray;

    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }
        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }

        // Set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();
    }

    private void Update()
    {
        itemCursor.SetActive(isMovingItem && !isCrafting);
        itemCursor.transform.position = Input.mousePosition;
        if (isMovingItem && !isCrafting)
            itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().itemIcon;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Selectable")
            {
                isOverInteractable = true;
            }
        }
        else
            isOverInteractable = false;

        if (Input.GetMouseButtonDown(0)) //we clicked!
        {
            //find the closest slot (the slot we clicked on)
            if (isMovingItem)
            {
                EndItemMove();
            }
            else
                BeginItemMove();
        }
    }

    #region Inventory Utils

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;

                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }

            catch
            {
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public bool Add(SO_ItemClass item, int quantity)
    {
        SlotClass slot = Contains(item);
        if (slot != null)
            slot.AddQuantity(1);
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null) //this is an empty slot
                {
                    items[i].AddItem(item, quantity);
                    break;
                }
            }
        }
        RefreshUI();
        return true;
    }

    public bool Remove(SO_ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
                temp.SubQuantity(1);
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }
                items[slotToRemoveIndex].Clear();
            }
        }
        else
            return false;

        RefreshUI();
        return true;
    }

    public void HandleItemPickup(SO_ItemClass item)
    {
        if (item != null)
            Add(item, 1);
    }

    public void HandleRemoveItem(SO_ItemClass item)
    {
        if (item != null)
            Remove(item);
    }

    public SlotClass Contains(SO_ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == item)
                return items[i];
        }
        return null;
    }

    #endregion Inventory Utils

    #region Dragging Inventory Items

    private bool BeginItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.GetItem() == null)
            return false; // There is no item to move!

        movingSlot = new SlotClass(originalSlot); // Item in our hand!
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null)
        {
            Add(movingSlot.GetItem(), movingSlot.GetQuantity());
            movingSlot.Clear();
        }
        else
        {
            if (originalSlot.GetItem() != null)
            {
                if (originalSlot.GetItem() == movingSlot.GetItem())
                {
                    if (originalSlot.GetItem().isStackable)
                    {
                        originalSlot.AddQuantity(movingSlot.GetQuantity());
                        movingSlot.Clear();
                    }
                    else
                        return false;
                }
                else
                {
                    if (craftingManager.CanCraft(originalSlot.GetItem(), movingSlot.GetItem())) //craft
                    {
                        isCrafting = true;
                        // Raise the crafted event
                        craftingManager.CraftItems(originalSlot.GetItem(), movingSlot.GetItem());
                        movingSlot.Clear();
                    }
                    else
                    {
                        tempSlot = new SlotClass(originalSlot); //a=b
                        originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity()); //b=c
                        movingSlot.AddItem(tempSlot.GetItem(), tempSlot.GetQuantity()); //a=c
                    }

                    RefreshUI();
                    return true;
                }
            }
            else //place item as usual
            {
                originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                movingSlot.Clear();
            }
        }

        isMovingItem = false;
        isCrafting = false;
        RefreshUI();
        return true;
    }

    private SlotClass GetClosestSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32)
                return items[i];
        }

        return null;
    }

    #endregion Dragging Inventory Items

}