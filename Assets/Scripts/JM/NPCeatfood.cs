using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCeatfood : MonoBehaviour
{
    void Update()
    {
        // 레이저를 쏘는 시작점과 방향 설정
        Vector3 rayOrigin = transform.position; // 시작점은 현재 객체의 위치로 설정
        Vector3 rayDirection = transform.TransformDirection(Vector3.forward); // 정면 방향으로 설정

        // 레이캐스트를 실행하고 충돌 정보를 저장할 변수
        RaycastHit hit;
        Ray ray = new Ray(rayOrigin, rayDirection);

        // 레이캐스트 실행
        if (Physics.Raycast(ray, out hit))
        {
            // 충돌한 객체의 태그를 확인하여 반응
            if (hit.collider.CompareTag("coffee"))
            {
                // 원하는 동작을 수행
                Debug.Log("맛있는 커피네요!");
            }
            else if (hit.collider.CompareTag("milk"))
            {
                Debug.Log("제가 원하던 라떼커피에요!!");
            }
        }

        // 레이를 시각적으로 그리기
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
    }
}
