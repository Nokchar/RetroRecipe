using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSandwich : MonoBehaviour
{
 
    public GameObject oliveObject;
    public GameObject hamObject; // ������ ���ο� ������Ʈ�� �����մϴ�.
    public float raycastLength = 1f; // Raycast�� ���̸� �����մϴ�.

    void Update()
    {
        bool hitCheese = false, hitEgg = false, hitOlive = false, hitHam = false; // �� �±׸� ���� ������Ʈ�� �����Ǿ����� �����մϴ�.
        GameObject cheeseObject = null, eggObject = null, oliveObject = null, hamObject = null; // �� �±׸� ���� ������Ʈ�� ���� ������ �����մϴ�.

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.up, raycastLength); // Raycast�� y�� �������� ���� ���, �浹�� ��� ������Ʈ�� ��ȯ�մϴ�.
        Debug.DrawRay(transform.position, Vector3.up * raycastLength, Color.red); // ����׿� ���ñ����� �׸��ϴ�.

        foreach (RaycastHit hit in hits) // ������ �浹�� ������Ʈ�� ����
        {
            if (hit.collider.CompareTag("Cheese")) // ���� ������Ʈ�� Cheese �±׸� �����ٸ�
            {
                hitCheese = true;
                cheeseObject = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("egg")) // ���� ������Ʈ�� egg �±׸� �����ٸ�
            {
                hitEgg = true;
                eggObject = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("olive")) // ���� ������Ʈ�� olive �±׸� �����ٸ�
            {
                hitOlive = true;
                oliveObject = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("ham")) // ���� ������Ʈ�� ham �±׸� �����ٸ�
            {
                hitHam = true;
                oliveObject = hit.collider.gameObject;
            }
        }

        if (hitCheese && hitEgg && hitOlive) // ���� Cheese, egg, olive �±׸� ���� ������Ʈ�� ��� �����Ǿ��ٸ�
        {
            Destroy(cheeseObject); // Cheese �±׸� ���� ������Ʈ�� �����մϴ�.
            Destroy(eggObject); // egg �±׸� ���� ������Ʈ�� �����մϴ�.
            Destroy(oliveObject); // olive �±׸� ���� ������Ʈ�� �����մϴ�.
            Instantiate(oliveObject, transform.position, Quaternion.identity); // ���ο� ������Ʈ�� �����մϴ�.
        }
        else if (hitCheese && hitEgg && hitHam) // ���� Cheese, egg, ham �±׸� ���� ������Ʈ�� ��� �����Ǿ��ٸ�
        {
            Destroy(cheeseObject); // Cheese �±׸� ���� ������Ʈ�� �����մϴ�.
            Destroy(eggObject); // egg �±׸� ���� ������Ʈ�� �����մϴ�.
            Destroy(hamObject); // olive �±׸� ���� ������Ʈ�� �����մϴ�.
            Instantiate(hamObject, transform.position, Quaternion.identity); // ���ο� ������Ʈ�� �����մϴ�.
        }
    }
}
