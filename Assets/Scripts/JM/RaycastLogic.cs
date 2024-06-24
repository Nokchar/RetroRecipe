using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLogic : MonoBehaviour
{
    public GameObject newObject; // 생성할 새로운 오브젝트를 지정합니다.
    public float raycastLength = 10f; // Raycast의 길이를 지정합니다.

    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();

        bool hitA = false, hitB = false, hitC = false; // 각 태그를 가진 오브젝트가 감지되었는지 추적합니다.

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.up, raycastLength); // Raycast를 y축 방향으로 위로 쏘고, 충돌한 모든 오브젝트를 반환합니다.
        Debug.DrawRay(transform.position, Vector3.up * raycastLength, Color.red); // 디버그용 가시광선을 그립니다.

        foreach (RaycastHit hit in hits) // 각각의 충돌한 오브젝트에 대해
        {
            if (hit.collider.CompareTag("Cheese")) // 만약 오브젝트가 a 태그를 가진다면
            {
                hitA = true;
                Debug.Log("치즈감지");
            }
            else if (hit.collider.CompareTag("egg")) // 만약 오브젝트가 b 태그를 가진다면
            {
                hitB = true;
                Debug.Log("계란감지");
            }
            else if (hit.collider.CompareTag("olive")) // 만약 오브젝트가 c 태그를 가진다면
            {
                hitC = true;
                Debug.Log("올리브감지");
            }
        }

        if (hitA && hitB && hitC) // 만약 a, b, c 태그를 가진 오브젝트가 모두 감지되었다면
        {
            Debug.Log("모두감지");
            foreach (RaycastHit hit in hits) // 각각의 충돌한 오브젝트에 대해
            {
                if (hit.collider.CompareTag("Cheese") || hit.collider.CompareTag("egg") || hit.collider.CompareTag("olive")) // 만약 오브젝트가 a, b, c 태그 중 하나를 가진다면
                {
                    Destroy(hit.collider.gameObject); // 기존 오브젝트를 삭제합니다.
                    Instantiate(newObject, hit.collider.transform.position, Quaternion.identity); // 새로운 오브젝트를 생성합니다.
                }
            }
        }
    }
}


