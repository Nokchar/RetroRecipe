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
    public float growthDuration = 3f; // ���� �ð� (3��)
    public float targetScaleY = 1.4f; // ��ǥ ������ Y ��

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
            Debug.Log("Ŀ�ǰ���!");
            // ���� �ݶ��̴��� �浹���� �� Ŀ�� ������Ʈ�� Ȱ��ȭ�ϰ� �������� ������ Ű��ϴ�.
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