using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GrabSwitch()
    {
        this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        this.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
    }
}
