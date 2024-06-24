using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fripan : MonoBehaviour
{
    public string collectibleTag = "Food";
    public Transform spawnPoint;
    public GameObject newObjectPrefab;
    public List<GameObject> collectedObjects = new List<GameObject>();
    public bool isHeating = false;
    public float heatingTime = 3.0f; // 가열 시간 (초)

    private void Update()
    {
        // 가스렌지가 가열 중이고, 충분한 오브젝트가 모였다면
        if (isHeating && collectedObjects.Count >= 1)
        {
            Debug.Log("요리시작");
            heatingTime -= Time.deltaTime;
            if (heatingTime <= 0)
            {
                foreach (GameObject obj in collectedObjects)
                {
                    Destroy(obj); // 기존 오브젝트 제거
                }
                collectedObjects.Clear();
                Instantiate(newObjectPrefab, spawnPoint.position, spawnPoint.rotation); // 새 오브젝트 생성
                
            }
        }
    }

    public void StartHeating()
    {
        isHeating = true; // 가열 시작
        heatingTime = 3.0f; // 타이머 재설정
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(collectibleTag))
        {
            collectedObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            StartHeating(); // 콜라이더와 충돌하면 가열 시작
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            isHeating = false;  // 가열 중지
        }
    }
}
