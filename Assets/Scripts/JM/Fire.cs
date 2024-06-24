using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public ParticleSystem fireParticle;
    public GameObject myObject;
    public AudioSource myAudioSource;

    private bool isIgnited = false;

    void Update()
    {
        if (this.transform.rotation.eulerAngles.z >= 50 && !isIgnited)
        {
            Debug.Log("��ȭȮ��");
            fireParticle.Play();
            myAudioSource.Play();
            ToggleObject();

            isIgnited = true;

            StartCoroutine(StopFireAfterSeconds(10)); // 15�� �Ŀ� ���� ���ϴ�.
        }
        else if (this.transform.rotation.eulerAngles.z < 50 && isIgnited)
        {
            StopFire();
        }
    }

    private void ToggleObject()
    {
        myObject.SetActive(true);
    }

    private void StopFire()
    {
        fireParticle.Stop();
        myAudioSource.Stop();
        myObject.SetActive(false);

        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.z = 0;
        this.transform.rotation = Quaternion.Euler(rotation);

        isIgnited = false;
    }

    IEnumerator StopFireAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds); // ������ �ð� ���� ����մϴ�.

        if (isIgnited) // ���� ���� ���� �ִٸ� ���ϴ�.
        {
            StopFire();
        }
    }
}
