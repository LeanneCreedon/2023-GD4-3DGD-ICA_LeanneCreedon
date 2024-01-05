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
    // Getting references to the inventory UI
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private CraftingManager craftingManager;

    [SerializeField] private SlotClass[] startingItems;

    public SlotClass[] items;

    private GameObject[] slots;

    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;

    private bool isOverInteractable;
    bool isMovingItem;
    bool isCrafting;
    RaycastHit hit;
    Ray ray;

    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];

        // Setting up new Slot classes for each slot on UI
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }

        // Setting up the starting items referenced in the inspector
        // (not using as player begins with empty inventory, but useful to have for testing)
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
        // Setting the Item Cursor to active if the player is currently moving an item and they are not crafting
        itemCursor.SetActive(isMovingItem && !isCrafting);
        // Moving the cursor with the mouse transform
        itemCursor.transform.position = Input.mousePosition;
        // If the player is moving and item and is not crafting, then set the cursor icon to the allocated item icon sprite.
        if (isMovingItem && !isCrafting)
            itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().itemIcon;

        // Checking if the mouse is over an interactable
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

        // When player clicks on screen, execute these methods...
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

    // Refresh UI, this is to keep the UI up to date with what the player is doing
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                // Setting the slot images to the current item allocated to that slot
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;

                // Only show the quantity if the item is stackable, otherwise do not display quantity text
                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }

            catch
            {
                // If there is an error, just set all slot images and quantities to null/empty
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    // Method to add a new item to the inventory
    public bool Add(SO_ItemClass item, int quantity)
    {
        SlotClass slot = Contains(item);
        // If the slot already contains the item, add 1 to the quantity of that item
        if (slot != null)
            slot.AddQuantity(1);
        else //Otherwise...
        {
            // Find an empty slot and place the item in that slot
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null) //this is an empty slot
                {
                    items[i].AddItem(item, quantity);
                    break;
                }
            }
        }
        // Refreash the inventory UI to keep it up to date with the status of the players inventory
        RefreshUI();
        return true;
    }

    // Method to remove an item from the inventory
    public bool Remove(SO_ItemClass item)
    {
        SlotClass temp = Contains(item);
        // If the item is in the inventory...
        if (temp != null)
        {
            // If there is more than one, deduct 1 from the quantity
            if (temp.GetQuantity() > 1)
                temp.SubQuantity(1);
            else // Otherwise...
            {
                int slotToRemoveIndex = 0;

                // Find the allocated slot for the item
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }
                // Remove the item from the inventory UI
                items[slotToRemoveIndex].Clear();
            }
        }
        else
            return false;

        RefreshUI();
        return true;
    }

    // This gets called by the event listener on the Event Manager whenever an item is picked up. The event is raised in the Pickup Script.
    public void HandleItemPickup(SO_ItemClass item)
    {
        if (item != null)
            Add(item, 1);
    }

    // This gets called by the event listener on the Event Manager whenever an item is removed.
    public void HandleRemoveItem(SO_ItemClass item)
    {
        if (item != null)
            Remove(item);
    }

    // Method to check if an item is in the inventory
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

    // Method to handle when the player begins to move an item in the inventory
    private bool BeginItemMove()
    {
        // Getting the closest slot to where the player last clicked
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.GetItem() == null)
            return false; // There is no item to move!

        movingSlot = new SlotClass(originalSlot); // Item in our hand!
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    // Method to handle when the player has finished moving the item
    private bool EndItemMove()
    {
        // Getting the closest slot to where the player last clicked
        originalSlot = GetClosestSlot();
        // If original slot is empty, add item as normal
        if (originalSlot == null)
        {
            Add(movingSlot.GetItem(), movingSlot.GetQuantity());
            movingSlot.Clear();
        }
        else // otherwise...
        {
            // If the original slot the player moved the item from is not null...
            if (originalSlot.GetItem() != null)
            {
                // If the original slot item is the same as the moving slot item...
                if (originalSlot.GetItem() == movingSlot.GetItem())
                {
                    // If the original slot item is stackable...
                    if (originalSlot.GetItem().isStackable)
                    {
                        // Add to the quantity of the stackable item (such as apple)
                        originalSlot.AddQuantity(movingSlot.GetQuantity());
                        // Clear the moving slot data
                        movingSlot.Clear();
                    }
                    else
                        return false;
                }
                else // Otherwise...
                {
                    // If the orignal slot item and the moving slot item are craftable together...
                    if (craftingManager.CanCraft(originalSlot.GetItem(), movingSlot.GetItem())) //craft
                    {
                        // Set isCrafting to true and craft the items...
                        isCrafting = true;
                        // Raise the crafted event - (would have used this method for better approach)
                        craftingManager.CraftItems(originalSlot.GetItem(), movingSlot.GetItem());
                        movingSlot.Clear();
                    }
                    else // Otherwise...
                    {
                        // Swap the two items so that the original slot item becomes the moving slot
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

    // Method to get the closest slot to where the player clicked last
    private SlotClass GetClosestSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32) // setting a range of 32
                return items[i];
        }

        return null;
    }

    #endregion Dragging Inventory Items

}