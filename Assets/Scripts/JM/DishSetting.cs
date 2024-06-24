using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishSetting : MonoBehaviour
{
    public GameObject breadTomatoPrefab; 

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 빵과 토마토인지 확인
        if (collision.gameObject.CompareTag("Bread") && collision.gameObject.CompareTag("Tomato"))
        {
            // 새로운 프리팹 생성
            Debug.Log("check");
            Instantiate(breadTomatoPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
