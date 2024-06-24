using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하기 위해 추가합니다.

public class CoffeeFill2 : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    private bool isActivated = false;
    private float particleDuration = 3f; // 파티클 재생 시간 (3초)
    [SerializeField]
    private Collider myCollider;
    [SerializeField]
    private Image gauge; // 게이지 UI를 참조합니다.

    // 버튼을 누를 때 호출되는 함수
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
            myCollider.enabled = true; // 파티클이 켜질 때 콜라이더를 활성화합니다.
            isActivated = true;
            StartCoroutine(FillGauge()); // 게이지를 채우는 코루틴을 시작합니다.
        }
        else
        {
            particleSystem.Stop();
            myCollider.enabled = false; // 파티클이 꺼질 때 콜라이더를 비활성화합니다.
            isActivated = false;
        }
    }

    private IEnumerator StopParticleAfterDuration()
    {
        yield return new WaitForSeconds(particleDuration);
        ToggleParticle(); // 파티클을 꺼줍니다.
        yield return new WaitForSeconds(5); // 5초 동안 대기합니다.
        gauge.fillAmount = 0; // 게이지를 초기화합니다.
    }

    private IEnumerator FillGauge()
    {
        float time = 0;

        while (time < particleDuration)
        {
            time += Time.deltaTime;
            gauge.fillAmount = time / particleDuration; // 게이지를 채웁니다.
            yield return null;
        }
    }
}
