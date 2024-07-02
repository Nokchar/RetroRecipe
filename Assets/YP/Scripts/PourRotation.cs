using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourRotation : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] private string xyz;

    [SerializeField] private GameObject particle;

    [NonSerialized] public bool rot;

    void Update()
    {
        HandleRotation(min, max, xyz);
    }
    private void HandleRotation(int min, int max, string xyz)
    {
        float rotxyz;
        switch (xyz)
        {
            case "x":
                rotxyz = this.transform.eulerAngles.x;
                break;

            case "y":
                rotxyz = this.transform.eulerAngles.y;
                break;

            case "z":
                rotxyz = this.transform.eulerAngles.z;
                break;
            default:
                rotxyz = 0;
                Debug.LogError("rotation not set");
                break;
        }

        if ( rotxyz > min && rotxyz < max )
        {
            particle.GetComponent<ParticleSystem>().Play();
            rot = true;
        }
        else
        {
            particle.GetComponent<ParticleSystem>().Stop();
            rot = false;
        }
    }
}
