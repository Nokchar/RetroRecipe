using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ����ϱ� ���� �߰��մϴ�.

public class CoffeeFill2 : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    private bool isActivated = false;
    private float particleDuration = 3f; // ��ƼŬ ��� �ð� (3��)
    [SerializeField]
    private Collider myCollider;
    [SerializeField]
    private Image gauge; // ������ UI�� �����մϴ�.

    // ��ư�� ���� �� ȣ��Ǵ� �Լ�
    public void OnButtonClick()
    {
        ToggleParticle();
        StartCoroutine(StopParticleAfterDuration());
    }

    private void ToggleParticle()
    {
        if (!isActivated)
        {
            particleSystem.Play();
            myCollider.enabled = true; // ��ƼŬ�� ���� �� �ݶ��̴��� Ȱ��ȭ�մϴ�.
            isActivated = true;
            StartCoroutine(FillGauge()); // �������� ä��� �ڷ�ƾ�� �����մϴ�.
        }
        else
        {
            particleSystem.Stop();
            myCollider.enabled = false; // ��ƼŬ�� ���� �� �ݶ��̴��� ��Ȱ��ȭ�մϴ�.
            isActivated = false;
        }
    }

    private IEnumerator StopParticleAfterDuration()
    {
        yield return new WaitForSeconds(particleDuration);
        ToggleParticle(); // ��ƼŬ�� ���ݴϴ�.
        yield return new WaitForSeconds(5); // 5�� ���� ����մϴ�.
        gauge.fillAmount = 0; // �������� �ʱ�ȭ�մϴ�.
    }

    private IEnumerator FillGauge()
    {
        float time = 0;

        while (time < particleDuration)
        {
            time += Time.deltaTime;
            gauge.fillAmount = time / particleDuration; // �������� ä��ϴ�.
            yield return null;
        }
    }
}
