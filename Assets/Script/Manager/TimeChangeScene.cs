using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeChangeScene : MonoBehaviour
{

    [SerializeField] private string _loadScene;
    public int _delay; //íxâÑÇ≥ÇπÇΩÇ¢ïbêî

    public void TimeLag()
    {
        Invoke("SceneChange", _delay);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(_loadScene);
    }
}