using UnityEngine;

[CreateAssetMenu(fileName = "new Quest Item Class", menuName = "Scriptable Objects/Item/QuestCollectable")]
public class QuestCollectable : SO_ItemClass
{
    // Data specific to Quest Collectable class

    public override SO_ItemClass GetItem() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override QuestCollectable GetQuestCollectable() { return this; }
}

