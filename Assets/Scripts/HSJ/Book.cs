using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject bookEffect;
    public GameObject bookButton;

    public void SpawnBook()
    {
        bookEffect.SetActive(true);
        bookButton.SetActive(true);
    }
}
