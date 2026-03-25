//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using Unity.VisualScripting;

//public class ItemUIManager : MonoBehaviour
//{
//    [SerializeField] private StrollItemDataBase database;
//    [SerializeField] private GameObject slotPrefab;
//    [SerializeField] private Transform slotParent;

//    [Header("è⁄ç◊UI")]
//    [SerializeField] private Image datailIcon;
//    [SerializeField] private Text detailName;
//    [SerializeField] private Text detailDescription;


//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        CreateSlots(database.GetAllItems());
//    }

//    void CreateSlots(List<ItemData> items)
//    {
//        foreach (var item in items)
//        {
//            GameObject slot = Instantiate(slotPrefab, slotParent);
//            var slotScript = slot.GetComponent<Itemslot>();
//            slotScript.Setup(item, this);
//        }
//    }

//    public void ShowItemInfo(ItemData item)
//    {
//        datailIcon.sprite = item.icon;
//        detailName.text = item.itemName;
//        detailDescription.text = item.description;
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
