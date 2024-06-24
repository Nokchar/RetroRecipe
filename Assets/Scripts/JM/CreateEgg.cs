using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateEgg : MonoBehaviour
{
    public GameObject eggPrefab;

    public Transform eggfri;

   public void SmashEgg()
    {

        Instantiate(eggPrefab, eggfri.position, eggfri.rotation);
        
    }
}
