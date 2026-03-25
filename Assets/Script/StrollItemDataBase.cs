using System.Collections.Generic;
using UnityEngine;

public class StrollItemDataBase : MonoBehaviour
{
    [SerializeField] private List<ItemData> ItemList;

    public List<ItemData> GetAllItems()
    {
        return ItemList;
    }
}
