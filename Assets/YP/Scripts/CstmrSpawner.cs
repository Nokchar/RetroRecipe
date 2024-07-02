using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CstmrSpawner : MonoBehaviour
{
    //private bool open;
    private bool empty;
    [NonSerialized] public int randomIdx;

    void Start()
    {
        //open = true;
        empty = true;
    }

    void Update()
    {
        //if (open && empty)
        if (empty)
        {
            empty = false;
            cstmrSpawn();
        }
    }

    private void cstmrSpawn()
    {
        var cstmrs = CSVManager.Instance.cstmrs;
        randomIdx = UnityEngine.Random.Range(0, cstmrs.Count);
        Debug.Log(randomIdx);
        var randomPrefab = cstmrs.ElementAt(randomIdx).Key;
        GameObject cstmrPrefab = Resources.Load("YP/Cstmrs/" + randomPrefab) as GameObject;
        var spawnSpot = ObjectManager.Instance.spawnSpot;
        GameObject cstmr = Instantiate(cstmrPrefab, spawnSpot.position, spawnSpot.rotation);
    }
}