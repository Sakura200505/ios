using UnityEngine;

public class WalkUIManager : MonoBehaviour
{
    [Header("ŽU•à’†UI")]
    [SerializeField] private GameObject walkPanel;

    [Header("ƒyƒbƒg‚ÌUI")]
    [SerializeField] private GameObject petObject;
   
    // Update is called once per frame
    private void Update()
    {
        if (WalkManager.Instance.isWalking)
        {
            walkPanel.SetActive(true);
            petObject.SetActive(false);
        }
        else
        {
            walkPanel.SetActive(false);
            petObject.SetActive(true);
        }
    }
}
