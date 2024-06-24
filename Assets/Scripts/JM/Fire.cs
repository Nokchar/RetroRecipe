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
            Debug.Log("점화확인");
            fireParticle.Play();
            myAudioSource.Play();
            ToggleObject();

            isIgnited = true;

            StartCoroutine(StopFireAfterSeconds(10)); // 15초 후에 불을 끕니다.
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
        yield return new WaitForSeconds(seconds); // 지정된 시간 동안 대기합니다.

        if (isIgnited) // 만약 불이 켜져 있다면 끕니다.
        {
            StopFire();
        }
    }
}
