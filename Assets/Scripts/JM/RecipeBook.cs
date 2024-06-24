using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour
{
    public Image imageComponent; 
    public Sprite[] sprites; 
    private int currentIndex = 0;

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % sprites.Length;
        imageComponent.sprite = sprites[currentIndex];
    }

    public void PreviousImage()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = sprites.Length - 1;
        }
        imageComponent.sprite = sprites[currentIndex];
    }
}
