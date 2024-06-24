using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SandwichMaker : MonoBehaviour
{
    public GameObject bread;
    public GameObject olive;
    public GameObject cheese;
    public GameObject egg;

    public List<GameObject> collectedObjects = new List<GameObject>();

    public GameObject sandwichPrefab;

    public Transform spawnPoint;


    public bool isCheeseAdded = false;
    public bool isEggAdded = false;
    public bool isOliveAdded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == cheese)
        {
            isCheeseAdded = true;
            collectedObjects.Add(collision.gameObject);
            collectedObjects.Add(this.gameObject);

        }
        if (collision.gameObject.CompareTag("egg"))
        {
            isEggAdded = true;
            collectedObjects.Add(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Tomato"))
        {
            isOliveAdded = true;
            collectedObjects.Add(collision.gameObject);
        }




    }
    private void Update()
    {
        if (isCheeseAdded && isEggAdded && isOliveAdded)
        {
            foreach (GameObject obj in collectedObjects)
            {
                Destroy(obj); // 기존 오브젝트 제거
            }
            Debug.Log("치즈 샌드위치 완성!");
            
            collectedObjects.Clear();
            
            Instantiate(sandwichPrefab, spawnPoint.position, spawnPoint.rotation);

            isCheeseAdded = false;
            isEggAdded = false;
            isOliveAdded = false;


        }


    }
}
