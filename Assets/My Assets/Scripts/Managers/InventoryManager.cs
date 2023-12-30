using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    public List<SO_ItemClass> items = new List<SO_ItemClass>();

    private GameObject[] slots;
    private SO_ItemClass itemToAdd;

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

    public void HandleQuestItemPickup(SO_ItemClass item)
    {
        Debug.Log("IN HandleQuestItemPickup()!");
        Add(item);
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

    //void Update()
    //{
    //    HandleQuestItemPickup();
    //}
}
