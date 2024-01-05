using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Series Followed:
/// Let's make an Inventory System! ErenCode -
/// https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx
/// accessed - 25/12/2023
/// ---------------------
/// Script for handling quest collectable item data
/// </summary>
[CreateAssetMenu(fileName = "new Quest Item Class", menuName = "Scriptable Objects/Item/QuestCollectable")]
public class QuestCollectable : SO_ItemClass
{
    // Data specific to Quest Collectable class

    public override SO_ItemClass GetItem() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override QuestCollectable GetQuestCollectable() { return this; }
}

