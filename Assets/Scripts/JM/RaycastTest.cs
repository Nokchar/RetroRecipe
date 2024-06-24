using UnityEngine;
using System.Collections.Generic;

public class RaycastTest : MonoBehaviour
{
    public GameObject oliveObject;
    public GameObject hamObject;
    public GameObject tomatoObject;
     
    public float raycastLength = 1f;

    void Update()
    {
        
        List<GameObject> hitObjects = new List<GameObject>(); // ������ ������Ʈ�� �����ϴ� ����Ʈ�� �����մϴ�.
        bool hitCheese = false, hitEgg = false, hitHam = false, hitOlive = false, hitTomato = false; // �� �±׸� ���� ������Ʈ�� �����Ǿ����� �����մϴ�.

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.up, raycastLength); // Raycast�� y�� �������� ���� ���, �浹�� ��� ������Ʈ�� ��ȯ�մϴ�.
        Debug.DrawRay(transform.position, Vector3.up * raycastLength, Color.red); // ����׿� ���ñ����� �׸��ϴ�.

        foreach (RaycastHit hit in hits) // ������ �浹�� ������Ʈ�� ����
        {
            if (hit.collider.CompareTag("Cheese")) // ���� ������Ʈ�� Cheese �±׸� �����ٸ�
            {
                hitCheese = true;
                hitObjects.Add(hit.collider.gameObject); // �ش� ������Ʈ�� ����Ʈ�� �߰��մϴ�.
            }
            else if (hit.collider.CompareTag("egg")) // ���� ������Ʈ�� egg �±׸� �����ٸ�
            {
                hitEgg = true;
                hitObjects.Add(hit.collider.gameObject); // �ش� ������Ʈ�� ����Ʈ�� �߰��մϴ�.
            }
            else if (hit.collider.CompareTag("ham")) // ���� ������Ʈ�� ham �±׸� �����ٸ�
            {
                hitHam = true;
                hitObjects.Add(hit.collider.gameObject); // �ش� ������Ʈ�� ����Ʈ�� �߰��մϴ�.
            }
            else if (hit.collider.CompareTag("olive")) // ���� ������Ʈ�� olive �±׸� �����ٸ�
            {
                Debug.Log("olive!!!");
                hitOlive = true;
                hitObjects.Add(hit.collider.gameObject); // �ش� ������Ʈ�� ����Ʈ�� �߰��մϴ�.
            }
            else if (hit.collider.CompareTag("Tomato")) // ���� ������Ʈ�� olive �±׸� �����ٸ�
            {
                Debug.Log("tomato!!!");
                hitTomato = true;
                hitObjects.Add(hit.collider.gameObject); // �ش� ������Ʈ�� ����Ʈ�� �߰��մϴ�.
            }
        }

        if (hitCheese && hitEgg && hitHam) // ���� Cheese, egg, ham �±׸� ���� ������Ʈ�� ��� �����Ǿ��ٸ�
        {
            foreach (GameObject obj in hitObjects) // ������ ��� ������Ʈ�� ����
            {
                Destroy(obj); // ������Ʈ�� �����մϴ�.
                Destroy(this.gameObject);
            }
            Instantiate(hamObject, this.transform.position, Quaternion.identity); // �ٸ� ������Ʈ�� �����մϴ�.
           
        }
        else if (hitCheese && hitEgg && hitOlive && hitEgg) // ���� Cheese, egg, olive �±׸� ���� ������Ʈ�� ��� �����Ǿ��ٸ�
        {
            foreach (GameObject obj in hitObjects) // ������ ��� ������Ʈ�� ����
            {
                Destroy(obj); // ������Ʈ�� �����մϴ�.
                Destroy(this.gameObject);

            }
            Instantiate(oliveObject, this.transform.position, Quaternion.identity); // ���ο� ������Ʈ�� �����մϴ�.
            
        }
        else if (hitHam && hitOlive && hitTomato) 
        {
            foreach (GameObject obj in hitObjects) // ������ ��� ������Ʈ�� ����
            {
                Destroy(obj); // ������Ʈ�� �����մϴ�.
                Destroy(this.gameObject);
                

            }
            Instantiate(tomatoObject, this.transform.position, Quaternion.identity); // ���ο� ������Ʈ�� �����մϴ�.
            

        }
    }
}
