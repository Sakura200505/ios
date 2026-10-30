using UnityEngine;

[CreateAssetMenu(fileName = "DressUpItem" , menuName = "Pet/DressUpItem")]
public class DressUpItemData : ScriptableObject
{
    public string itemId;
    public string itemName;
    public Sprite itemSprite;
}