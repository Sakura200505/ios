using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("SelectScene");
    }
}