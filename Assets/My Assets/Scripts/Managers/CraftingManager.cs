using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] public InventoryManager inventory;
    [SerializeField] public CraftingRecipe[] craftingRecipes;

    private SO_ItemClass craftResult;
    private CraftItem craftItemResponse;

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


/*using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] public InventoryManager inventory;
    [SerializeField] public CraftingRecipe[] craftingRecipes;

    public void CraftItems(SO_ItemClass item1, SO_ItemClass item2)
    {
        CraftingRecipe recipe = FindCraftingRecipe(item1, item2);
        if (recipe != null)
        {
            inventory.Remove(item1.GetItem());
            inventory.Remove(item2.GetItem());

            inventory.Add(recipe.craftedResult, 1);
        }
    }

    private CraftingRecipe FindCraftingRecipe(SO_ItemClass item1, SO_ItemClass item2)
    {
        // Search through the crafting recipes to find a match
        foreach (CraftingRecipe recipe in craftingRecipes)
        {
            if ((recipe.inputItem1 == item1 && recipe.inputItem2 == item2) ||
                (recipe.inputItem1 == item2 && recipe.inputItem2 == item1))
            {
                return recipe;
            }
        }
        return null; // No matching recipe found
    }
}
*/