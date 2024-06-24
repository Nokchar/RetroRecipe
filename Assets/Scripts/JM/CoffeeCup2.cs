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
    public float growthDuration = 3f; // ���� �ð� (3��)
    public float targetScaleY = 2f; // ��ǥ ������ Y ��

    public bool isCoffee = false;
    public bool isLatte = false;

    private void Start()
    {
        // �ʱ� ������ ����
        coffeeObject.transform.localScale = new Vector3(coffeeObject.transform.localScale.x, 0.4f, coffeeObject.transform.localScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == cupCollider)
        {
            
            // ���� �ݶ��̴��� �浹���� �� Ŀ�� ������Ʈ�� Ȱ��ȭ�ϰ� �������� ������ Ű��ϴ�.
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
            // DOTween�� ����Ͽ� �������� �����մϴ�.
            coffeeObject.transform.DOScaleY(targetScaleY, growthDuration);

            isCoffee = true;
            gameObject.tag = "coffee";

    }

}
