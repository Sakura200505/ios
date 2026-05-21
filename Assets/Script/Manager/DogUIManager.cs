using UnityEngine;
using UnityEngine.UI;

public class DogUIManager : MonoBehaviour
{
    public Image dogImage;

    [Header("Х\По")]
    public Sprite normalSprite;
    public Sprite hungrySprite;
    public Sprite dirtySprite;
    public Sprite stressSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDogFace();
    }

    void UpdateDogFace()
    {
        float hunger = StatusManager.Instance.hunger;
        float clean = StatusManager.Instance.clean;
        float stress = StatusManager.Instance.stress;

        if (hunger <= 30)
        {
            dogImage.sprite = hungrySprite;
        }

        else if (clean <= 30)
        {
            dogImage.sprite = dirtySprite;
        }

        else if ( stress >= 30)
        {
            dogImage.sprite= stressSprite;  
        }

        else
        {
            dogImage.sprite = normalSprite;
        }
    }
}

