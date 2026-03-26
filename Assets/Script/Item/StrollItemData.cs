using UnityEngine;


[CreateAssetMenu(menuName = "Game/Item")]

public class StrollItemData : ScriptableObject
{
    //itemの画像
    public Sprite icon;
    //itemの名前
    public string itemName;
    //itemのタイプ
    public ItemType itemType;

    [TextArea] public string description;

    public int foodValue;
    public int cleanlinessValue;

    public enum ItemType
    {
        Food,
        Shower,
        Clothes,
        Other
    }
}
