using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/CardData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public Sprite itemFrame;
    public int rarity; // 0:¯1, 1:¯2, ...
}