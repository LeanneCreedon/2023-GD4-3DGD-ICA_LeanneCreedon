using UnityEngine;

[CreateAssetMenu(fileName = "new Misc Class", menuName = "Scriptable Objects/Item/Misc")]
public class MiscClass : SO_ItemClass
{
    // Data specific to misc class

    public override SO_ItemClass GetItem() { return this; }
    public override MiscClass GetMisc() { return this; }
    public override QuestCollectable GetQuestCollectable() { return null; }
}
