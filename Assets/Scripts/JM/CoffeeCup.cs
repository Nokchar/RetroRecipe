using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCup : MonoBehaviour
{
    public Collider cupCollider;
    public Collider milkCollider;
    public GameObject coffeeObject;
    public GameObject cocoaObject;
    public float growthDuration = 3f; // 성장 시간 (3초)
    public float targetScaleY = 1.4f; // 목표 스케일 Y 값

    private bool isScaling = false;
    public bool isCoffee=false;
    public bool isLatte = false;
    private float initialScaleY;
    private float elapsedTime = 0f;

    private void Start()
    {
        initialScaleY = coffeeObject.transform.localScale.y;
    }

    private void Update()
    {
        if (isScaling)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / growthDuration);
            float newYScale = Mathf.Lerp(initialScaleY, targetScaleY, t);

            Vector3 newScale = coffeeObject.transform.localScale;
            newScale.y = newYScale;
            coffeeObject.transform.localScale = newScale;

            if (t >= 0.7f)
            {
                isScaling = false;
                elapsedTime = 0f;
            }
        }
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other == cupCollider)
        {
            Debug.Log("커피감지!");
            // 컵의 콜라이더와 충돌했을 때 커피 오브젝트를 활성화하고 스케일을 서서히 키웁니다.
            coffeeObject.SetActive(true);
            isScaling = true;

            isCoffee = true;
            gameObject.tag = "coffee";
        }
        if (other == milkCollider)
        {
            coffeeObject.SetActive(false);
            cocoaObject.SetActive(true);
            isLatte = true;
            gameObject.tag = "milk";

        }
    }
}