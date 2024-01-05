/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Series Followed:
/// Let's make an Inventory System! ErenCode -
/// https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx
/// accessed - 29/12/2023
/// ---------------------
/// Script to hold crafting recipes.
/// </summary>
[System.Serializable]
public class CraftingRecipe
{
    public SO_ItemClass inputItem1;
    public SO_ItemClass inputItem2;
    public SO_ItemClass craftedResult;
}
