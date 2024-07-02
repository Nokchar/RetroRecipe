using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CupController : MonoBehaviour
{
    private string[] mixes;
    public List<string> mixture = new List<string>();

    private float first;
    private float second;
    private float third;
    private string one;
    private string two;
    private string three;
    private GameObject fluid;
    private Vector3 initialScale;
    private Vector3 targetScale;

    private bool[] playOnce = new bool[10];

    void Start()
    {
        mixes = new string[] { "Coffee", "Tea", "GreenTea", "Chocolate", "Milk", "Water", "Ice", "Sugar", "Cream", "Honey", "Lemon", "Cinammon" };
        first = 0f; second = 0f; third = 0f;
        one = ""; two = ""; three = "";
        fluid = this.transform.GetChild(0).gameObject;
        initialScale = fluid.transform.localScale;
    }

    private void OnTriggerStay(Collider other)
    {

        if ( other.CompareTag("Mix") )
        {
            var mixName = other.name;
            bool rot = other.transform.parent.gameObject.GetComponent<PourRotation>().rot;

            if ( first < 1f && rot )
            {
                for (int i = 0; i < mixes.Length; i++)
                {
                    if (mixes[i] == mixName)
                    {
                        one = mixName;
                        fluid.GetComponent<MeshRenderer>().enabled = true;
                        FillupOne(mixName);
                        if (!playOnce[0])
                        {
                            playOnce[0] = true;
                            mixture.Add(mixName);
                        }
                    }
                }
                first += Time.deltaTime;
                float frac = first / 10f;
                if (mixes.Length == 1)
                {
                    targetScale = new Vector3(initialScale.x, initialScale.y + 3f, initialScale.z);
                }
                else
                {
                    targetScale = new Vector3(initialScale.x, initialScale.y + .1f, initialScale.z);
                }
                fluid.transform.localScale = Vector3.Lerp(fluid.transform.localScale, targetScale, frac);
            }
            else if (first >= 1f && second < 1f && mixName != one && rot)
            {
                for (int j = 0; j < mixes.Length; j++)
                {
                    if (mixes[j] == mixName)
                    {
                        two = mixName;
                        FillupTwo(mixName);
                    }
                }
                second += Time.deltaTime;
                float frac = first / 10f;
                targetScale = new Vector3(initialScale.x, initialScale.y + .2f, initialScale.z);
                fluid.transform.localScale = Vector3.Lerp(fluid.transform.localScale, targetScale, frac);

            }
            else if ( first >= 1f && second >= 1f && mixName != two && rot )
            {
                for (int k = 0; k < mixes.Length; k++)
                {
                    if (mixes[k] == mixName)
                    {
                        three = mixName;
                        FillupThree(mixName);
                    }
                }
                third += Time.deltaTime;
                float frac = first / 10f;
                targetScale = new Vector3(initialScale.x, initialScale.y + .3f, initialScale.z);
                fluid.transform.localScale = Vector3.Lerp(fluid.transform.localScale, targetScale, frac);
            }
        }
    }

    private void FillupOne(string mix)
    {
        switch (mix)
        {
            case "Coffee":
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material = ObjectManager.Instance.Coffee;
                break;

            case "Tea":
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material = ObjectManager.Instance.Tea;
                break;

            case "GreenTea":
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material = ObjectManager.Instance.GreenTea;
                break;

            case "Chocolate":
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material = ObjectManager.Instance.Chocolate;
                break;

            case "Milk":
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material = ObjectManager.Instance.Milk;
                break;
        }
    }

    private void FillupTwo(string mix)
    {
        switch (mix)
        {
            case "Water":
                break;

            case "Milk":
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material = ObjectManager.Instance.Latte;
                break;

        }
    }

    private void FillupThree(string mix)
    {
        switch (mix)
        {
            case "Ice":
                break;

            case "Honey":
                break;

            case "Cinammon":
                // material
                break;
        }
    }

}
