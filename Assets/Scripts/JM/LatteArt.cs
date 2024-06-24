using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatteArt : MonoBehaviour
{
    public ParticleSystem milkpaticle;



    // Update is called once per frame
    void Update()
    {
        if (this.transform.rotation.eulerAngles.z >= 33 && this.transform.rotation.eulerAngles.z >= 0)
        {
            milkpaticle.Play();
        }
        else if (this.transform.rotation.eulerAngles.z < 33)
        {
            milkpaticle.Stop();
        }


    }
}
