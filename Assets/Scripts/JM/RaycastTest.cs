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
        
        List<GameObject> hitObjects = new List<GameObject>(); // 감지된 오브젝트를 저장하는 리스트를 생성합니다.
        bool hitCheese = false, hitEgg = false, hitHam = false, hitOlive = false, hitTomato = false; // 각 태그를 가진 오브젝트가 감지되었는지 추적합니다.

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.up, raycastLength); // Raycast를 y축 방향으로 위로 쏘고, 충돌한 모든 오브젝트를 반환합니다.
        Debug.DrawRay(transform.position, Vector3.up * raycastLength, Color.red); // 디버그용 가시광선을 그립니다.

        foreach (RaycastHit hit in hits) // 각각의 충돌한 오브젝트에 대해
        {
            if (hit.collider.CompareTag("Cheese")) // 만약 오브젝트가 Cheese 태그를 가진다면
            {
                hitCheese = true;
                hitObjects.Add(hit.collider.gameObject); // 해당 오브젝트를 리스트에 추가합니다.
            }
            else if (hit.collider.CompareTag("egg")) // 만약 오브젝트가 egg 태그를 가진다면
            {
                hitEgg = true;
                hitObjects.Add(hit.collider.gameObject); // 해당 오브젝트를 리스트에 추가합니다.
            }
            else if (hit.collider.CompareTag("ham")) // 만약 오브젝트가 ham 태그를 가진다면
            {
                hitHam = true;
                hitObjects.Add(hit.collider.gameObject); // 해당 오브젝트를 리스트에 추가합니다.
            }
            else if (hit.collider.CompareTag("olive")) // 만약 오브젝트가 olive 태그를 가진다면
            {
                Debug.Log("olive!!!");
                hitOlive = true;
                hitObjects.Add(hit.collider.gameObject); // 해당 오브젝트를 리스트에 추가합니다.
            }
            else if (hit.collider.CompareTag("Tomato")) // 만약 오브젝트가 olive 태그를 가진다면
            {
                Debug.Log("tomato!!!");
                hitTomato = true;
                hitObjects.Add(hit.collider.gameObject); // 해당 오브젝트를 리스트에 추가합니다.
            }
        }

        if (hitCheese && hitEgg && hitHam) // 만약 Cheese, egg, ham 태그를 가진 오브젝트가 모두 감지되었다면
        {
            foreach (GameObject obj in hitObjects) // 감지된 모든 오브젝트에 대해
            {
                Destroy(obj); // 오브젝트를 삭제합니다.
                Destroy(this.gameObject);
            }
            Instantiate(hamObject, this.transform.position, Quaternion.identity); // 다른 오브젝트를 생성합니다.
           
        }
        else if (hitCheese && hitEgg && hitOlive && hitEgg) // 만약 Cheese, egg, olive 태그를 가진 오브젝트가 모두 감지되었다면
        {
            foreach (GameObject obj in hitObjects) // 감지된 모든 오브젝트에 대해
            {
                Destroy(obj); // 오브젝트를 삭제합니다.
                Destroy(this.gameObject);

            }
            Instantiate(oliveObject, this.transform.position, Quaternion.identity); // 새로운 오브젝트를 생성합니다.
            
        }
        else if (hitHam && hitOlive && hitTomato) 
        {
            foreach (GameObject obj in hitObjects) // 감지된 모든 오브젝트에 대해
            {
                Destroy(obj); // 오브젝트를 삭제합니다.
                Destroy(this.gameObject);
                

            }
            Instantiate(tomatoObject, this.transform.position, Quaternion.identity); // 새로운 오브젝트를 생성합니다.
            

        }
    }
}
