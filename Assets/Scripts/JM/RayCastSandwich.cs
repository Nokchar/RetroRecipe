using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSandwich : MonoBehaviour
{
 
    public GameObject oliveObject;
    public GameObject hamObject; // 생성할 새로운 오브젝트를 지정합니다.
    public float raycastLength = 1f; // Raycast의 길이를 지정합니다.

    void Update()
    {
        bool hitCheese = false, hitEgg = false, hitOlive = false, hitHam = false; // 각 태그를 가진 오브젝트가 감지되었는지 추적합니다.
        GameObject cheeseObject = null, eggObject = null, oliveObject = null, hamObject = null; // 각 태그를 가진 오브젝트에 대한 참조를 저장합니다.

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.up, raycastLength); // Raycast를 y축 방향으로 위로 쏘고, 충돌한 모든 오브젝트를 반환합니다.
        Debug.DrawRay(transform.position, Vector3.up * raycastLength, Color.red); // 디버그용 가시광선을 그립니다.

        foreach (RaycastHit hit in hits) // 각각의 충돌한 오브젝트에 대해
        {
            if (hit.collider.CompareTag("Cheese")) // 만약 오브젝트가 Cheese 태그를 가진다면
            {
                hitCheese = true;
                cheeseObject = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("egg")) // 만약 오브젝트가 egg 태그를 가진다면
            {
                hitEgg = true;
                eggObject = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("olive")) // 만약 오브젝트가 olive 태그를 가진다면
            {
                hitOlive = true;
                oliveObject = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("ham")) // 만약 오브젝트가 ham 태그를 가진다면
            {
                hitHam = true;
                oliveObject = hit.collider.gameObject;
            }
        }

        if (hitCheese && hitEgg && hitOlive) // 만약 Cheese, egg, olive 태그를 가진 오브젝트가 모두 감지되었다면
        {
            Destroy(cheeseObject); // Cheese 태그를 가진 오브젝트를 삭제합니다.
            Destroy(eggObject); // egg 태그를 가진 오브젝트를 삭제합니다.
            Destroy(oliveObject); // olive 태그를 가진 오브젝트를 삭제합니다.
            Instantiate(oliveObject, transform.position, Quaternion.identity); // 새로운 오브젝트를 생성합니다.
        }
        else if (hitCheese && hitEgg && hitHam) // 만약 Cheese, egg, ham 태그를 가진 오브젝트가 모두 감지되었다면
        {
            Destroy(cheeseObject); // Cheese 태그를 가진 오브젝트를 삭제합니다.
            Destroy(eggObject); // egg 태그를 가진 오브젝트를 삭제합니다.
            Destroy(hamObject); // olive 태그를 가진 오브젝트를 삭제합니다.
            Instantiate(hamObject, transform.position, Quaternion.identity); // 새로운 오브젝트를 생성합니다.
        }
    }
}
