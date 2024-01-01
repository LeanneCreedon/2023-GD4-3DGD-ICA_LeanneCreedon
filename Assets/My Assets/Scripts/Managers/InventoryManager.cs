using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    //public SlotClass[] items;
    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];

        // Set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public bool Add(SO_ItemClass item)
    {
        SlotClass slot = Contains(item);
        if (slot == null)
            items.Add(new SlotClass(item));
        else
        {
            if (items.Count < slots.Length)
            {
                if (slot.GetItem().isCraftable)
                    Debug.Log(item.name + "Is Craftable");

                Debug.Log(item.name + " Is NOT Craftable");
            }
            else
                return false;
        }
        RefreshUI();
        return true;
    }

    public bool Remove(SO_ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            SlotClass slotToRemove = new SlotClass();
            foreach (SlotClass slot in items)
            {
                if (slot.GetItem() == item)
                {
                    slotToRemove = slot;
                    break;
                }
            }
            items.Remove(slotToRemove);
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public void HandleItemPickup(SO_ItemClass item)
    {
        Add(item);
    }

    public SlotClass Contains(SO_ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
                return slot;
        }
        return null;
    }
}

/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    public List<SO_ItemClass> items = new List<SO_ItemClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        // Set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public bool Add(SO_ItemClass item)
    {
        if (items.Count < slots.Length)
            items.Add(item);
        else
            return false;

        RefreshUI();
        return true;
    }

    public void Remove(SO_ItemClass item)
    {
        items.Remove(item);
        RefreshUI();
    }

    public void HandleItemPickup(SO_ItemClass item)
    {
        Add(item);

        // ANOTHER METHOD USING TAG

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(ray, out hitInfo))
        //    {
        //        if (hitInfo.collider.gameObject.tag == "Selectable")
        //        {
        //            itemToAdd = hitInfo.collider.GetComponent<Item>().GetItem();

        //            Add(itemToAdd);
        //            //Destroy(hitInfo.collider.gameObject);
        //        }
        //    }
        //}
    }

    public bool SearchForItem(SO_ItemClass item)
    {
        if (items.Contains(item))
            return true;
        else
            return false;
    }
}

*/