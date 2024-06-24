using DG.Tweening;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCup2 : MonoBehaviour
{
    public Collider cupCollider;
    public Collider milkCollider;
    public GameObject coffeeObject;
    public GameObject cocoaObject;
    public float growthDuration = 3f; // 성장 시간 (3초)
    public float targetScaleY = 2f; // 목표 스케일 Y 값

    public bool isCoffee = false;
    public bool isLatte = false;

    private void Start()
    {
        // 초기 스케일 설정
        coffeeObject.transform.localScale = new Vector3(coffeeObject.transform.localScale.x, 0.4f, coffeeObject.transform.localScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == cupCollider)
        {
            
            // 컵의 콜라이더와 충돌했을 때 커피 오브젝트를 활성화하고 스케일을 서서히 키웁니다.
            coffeeObject.SetActive(true);
            OnEvent1();
        }
        if (other == milkCollider)
        {
            coffeeObject.SetActive(true);
            OnEvent1();
        }
    }

    public void OnEvent1()
    {
            // DOTween을 사용하여 스케일을 변경합니다.
            coffeeObject.transform.DOScaleY(targetScaleY, growthDuration);

            isCoffee = true;
            gameObject.tag = "coffee";

    }

}
