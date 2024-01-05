using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Series Followed:
/// Let's make an Inventory System! ErenCode -
/// https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx
/// accessed - 25/12/2023
/// ---------------------
/// Script for handling misc item data
/// </summary>
[CreateAssetMenu(fileName = "new Misc Class", menuName = "Scriptable Objects/Item/Misc")]
public class MiscClass : SO_ItemClass
{
    // Data specific to misc class

    public override SO_ItemClass GetItem() { return this; }
    public override MiscClass GetMisc() { return this; }
    public override QuestCollectable GetQuestCollectable() { return null; }
}
