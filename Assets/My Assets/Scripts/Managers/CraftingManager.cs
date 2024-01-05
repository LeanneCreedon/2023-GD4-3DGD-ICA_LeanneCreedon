using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Series Followed:
/// Let's make an Inventory System! ErenCode -
/// https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx
/// accessed - 29/12/2023
/// ---------------------
/// Manager Script to manage crafting items in the inventory.
/// </summary>
public class CraftingManager : MonoBehaviour
{
    [SerializeField] public InventoryManager inventory;
    [SerializeField] public CraftingRecipe[] craftingRecipes;

    private SO_ItemClass craftResult;
    private CraftItem craftItemResponse;

    // If the items can be crafted, remove the two original items from the inventory and add the new one
    public void CraftItems(SO_ItemClass item1, SO_ItemClass item2)
    {
        if (CanCraft(item1, item2))
        {
            inventory.Remove(item1.GetItem());
            inventory.Remove(item2.GetItem());

            inventory.Add(craftResult, 1);
        }
    }

    public void HandleCraftResponse()
    {
        craftItemResponse.CraftResponse();
    }

    // Checking if you can craft these two items based on the recipies list set in the inspector
    public bool CanCraft(SO_ItemClass item1, SO_ItemClass item2)
    {
        // Search through the crafting recipes to find a match
        foreach (CraftingRecipe recipe in craftingRecipes)
        {
            if ((recipe.inputItem1 == item1 && recipe.inputItem2 == item2) ||
                (recipe.inputItem1 == item2 && recipe.inputItem2 == item1))
            {
                craftResult = recipe.craftedResult;
                return true;
            }
        }
        return false; // No matching recipe found
    }
}