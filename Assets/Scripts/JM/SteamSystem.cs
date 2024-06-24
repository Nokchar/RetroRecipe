using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSystem : MonoBehaviour
{
    public MoverLever mover;
    public ParticleSystem particleSystem2;
    private bool isActivated = false;
    private float particleDuration = 3f; // ��ƼŬ ��� �ð� (3��)

    private void Update()
    {
        if (mover.value >= 0.6f && !isActivated) // mover.value�� 0.6f�� �Ѿ���, ���� Ȱ��ȭ���� �ʾ��� ���� �����մϴ�.
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
        ToggleParticle(); // ��ƼŬ�� ���ݴϴ�.
    }
}
