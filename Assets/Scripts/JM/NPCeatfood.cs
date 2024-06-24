using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCeatfood : MonoBehaviour
{
    void Update()
    {
        // �������� ��� �������� ���� ����
        Vector3 rayOrigin = transform.position; // �������� ���� ��ü�� ��ġ�� ����
        Vector3 rayDirection = transform.TransformDirection(Vector3.forward); // ���� �������� ����

        // ����ĳ��Ʈ�� �����ϰ� �浹 ������ ������ ����
        RaycastHit hit;
        Ray ray = new Ray(rayOrigin, rayDirection);

        // ����ĳ��Ʈ ����
        if (Physics.Raycast(ray, out hit))
        {
            // �浹�� ��ü�� �±׸� Ȯ���Ͽ� ����
            if (hit.collider.CompareTag("coffee"))
            {
                // ���ϴ� ������ ����
                Debug.Log("���ִ� Ŀ�ǳ׿�!");
            }
            else if (hit.collider.CompareTag("milk"))
            {
                Debug.Log("���� ���ϴ� ��Ŀ�ǿ���!!");
            }
        }

        // ���̸� �ð������� �׸���
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
    }
}
