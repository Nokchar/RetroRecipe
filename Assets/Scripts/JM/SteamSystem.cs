using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSystem : MonoBehaviour
{
    public MoverLever mover;
    public ParticleSystem particleSystem2;
    private bool isActivated = false;
    private float particleDuration = 3f; // 파티클 재생 시간 (3초)

    private void Update()
    {
        if (mover.value >= 0.6f && !isActivated) // mover.value가 0.6f를 넘었고, 아직 활성화되지 않았을 때만 실행합니다.
        {
            OnButtonClick();
        }
    }

    public void OnButtonClick()
    {
        ToggleParticle();
        StartCoroutine(StopParticleAfterDuration());
    }

    private void ToggleParticle()
    {
        if (!isActivated)
        {
            particleSystem2.Play();
            isActivated = true;
        }
        else
        {
            particleSystem2.Stop();
            isActivated = false;
        }
    }

    private IEnumerator StopParticleAfterDuration()
    {
        yield return new WaitForSeconds(particleDuration);
        ToggleParticle(); // 파티클을 꺼줍니다.
    }
}
