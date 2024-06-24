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
    public float heatingTime = 3.0f; // ���� �ð� (��)

    private void Update()
    {
        // ���������� ���� ���̰�, ����� ������Ʈ�� �𿴴ٸ�
        if (isHeating && collectedObjects.Count >= 1)
        {
            Debug.Log("�丮����");
            heatingTime -= Time.deltaTime;
            if (heatingTime <= 0)
            {
                foreach (GameObject obj in collectedObjects)
                {
                    Destroy(obj); // ���� ������Ʈ ����
                }
                collectedObjects.Clear();
                Instantiate(newObjectPrefab, spawnPoint.position, spawnPoint.rotation); // �� ������Ʈ ����
                
            }
        }
    }

    public void StartHeating()
    {
        isHeating = true; // ���� ����
        heatingTime = 3.0f; // Ÿ�̸� �缳��
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
            StartHeating(); // �ݶ��̴��� �浹�ϸ� ���� ����
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            isHeating = false;  // ���� ����
        }
    }
}
