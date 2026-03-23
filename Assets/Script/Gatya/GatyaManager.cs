//using UnityEngine;

//public class GatyaManager : MonoBehaviour
//{
//    public ItemDataList itemDataList;
//    public GameObject itemPrefab;
//    public Transform displayParent; // カードを表示する位置

//    public void DrawItem()
//    {
//        ItemData drawn = itemDataList.GetRandomItem();
//        GameObject itemObj = Instantiate(itemPrefab, displayParent);
//        ItemDisplay display = itemObj.GetComponent();
//        display.SetItem(drawn);
//    }
//}