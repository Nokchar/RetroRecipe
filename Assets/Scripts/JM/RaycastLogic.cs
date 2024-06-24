using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLogic : MonoBehaviour
{
    public GameObject newObject; // ������ ���ο� ������Ʈ�� �����մϴ�.
    public float raycastLength = 10f; // Raycast�� ���̸� �����մϴ�.

    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();

        bool hitA = false, hitB = false, hitC = false; // �� �±׸� ���� ������Ʈ�� �����Ǿ����� �����մϴ�.

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.up, raycastLength); // Raycast�� y�� �������� ���� ���, �浹�� ��� ������Ʈ�� ��ȯ�մϴ�.
        Debug.DrawRay(transform.position, Vector3.up * raycastLength, Color.red); // ����׿� ���ñ����� �׸��ϴ�.

        foreach (RaycastHit hit in hits) // ������ �浹�� ������Ʈ�� ����
        {
            if (hit.collider.CompareTag("Cheese")) // ���� ������Ʈ�� a �±׸� �����ٸ�
            {
                hitA = true;
                Debug.Log("ġ���");
            }
            else if (hit.collider.CompareTag("egg")) // ���� ������Ʈ�� b �±׸� �����ٸ�
            {
                hitB = true;
                Debug.Log("�������");
            }
            else if (hit.collider.CompareTag("olive")) // ���� ������Ʈ�� c �±׸� �����ٸ�
            {
                hitC = true;
                Debug.Log("�ø��갨��");
            }
        }

        if (hitA && hitB && hitC) // ���� a, b, c �±׸� ���� ������Ʈ�� ��� �����Ǿ��ٸ�
        {
            Debug.Log("��ΰ���");
            foreach (RaycastHit hit in hits) // ������ �浹�� ������Ʈ�� ����
            {
                if (hit.collider.CompareTag("Cheese") || hit.collider.CompareTag("egg") || hit.collider.CompareTag("olive")) // ���� ������Ʈ�� a, b, c �±� �� �ϳ��� �����ٸ�
                {
                    Destroy(hit.collider.gameObject); // ���� ������Ʈ�� �����մϴ�.
                    Instantiate(newObject, hit.collider.transform.position, Quaternion.identity); // ���ο� ������Ʈ�� �����մϴ�.
                }
            }
        }
    }
}


