using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager instance;
    public static ObjectManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<ObjectManager>();

                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    GameObject newObj = new GameObject();
                    newObj.AddComponent<ObjectManager>();

                    instance = newObj.GetComponent<ObjectManager>();
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Transform playerPoint;
    public Transform spawnSpot;
    public GameObject door;
    public GameObject chair;
    public GameObject gameover;

    public Transform cstmrView;
    public Transform makingView;

    public GameObject tableMat;
    public GameObject brewMat;
    public TMP_Text listName;
    public TMP_Text listMemo;

    public Material Coffee;
    public Material Tea;
    public Material GreenTea;
    public Material Chocolate;
    public Material Milk;
    public Material Latte;

}
