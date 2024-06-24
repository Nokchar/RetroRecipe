using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishSetting : MonoBehaviour
{
    public GameObject breadTomatoPrefab; 

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ���� �丶������ Ȯ��
        if (collision.gameObject.CompareTag("Bread") && collision.gameObject.CompareTag("Tomato"))
        {
            // ���ο� ������ ����
            Debug.Log("check");
            Instantiate(breadTomatoPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
