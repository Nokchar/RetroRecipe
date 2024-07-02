using Autohand;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;

public class BaristaManager : MonoBehaviour
{
    private static BaristaManager instance;
    public static BaristaManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<BaristaManager>();

                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    GameObject newObj = new GameObject();
                    newObj.AddComponent<BaristaManager>();

                    instance = newObj.GetComponent<BaristaManager>();
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

    private CstmrSpawner cstmrSpawner;

    [NonSerialized] public string order;
    private string cup;

    void Start()
    {
        cstmrSpawner = FindObjectOfType<CstmrSpawner>();
    }
    
    public void CheckOrder()
    {
        int randomIdx = cstmrSpawner.randomIdx;
        order = CSVManager.Instance.cstmrs.ElementAt(randomIdx).Value[0];
    }

    public void ShowRecipe()
    {
        TMP_Text listName = ObjectManager.Instance.listName;
        TMP_Text listMemo = ObjectManager.Instance.listMemo;
        List<string> list = RecipeManager.Instance.RecipeFinder(order);
        listName.text = order;
        listMemo.text = string.Join("\n", list);
        Canvas.ForceUpdateCanvases();
    }

    public string CheckCup()
    {
        switch (order)
        {
            case "Espresso":
                return "EspressoCup";

            case "Americano":
            case "CafeLatte":
            case "SugarAndSpice":
            case "GreenTealatte":
            case "HotChocolate":
            case "ChocoLatte":
            case "SpicedLady":
                return "MugCup";

            case "IcedAmericano":
            case "IcedLatte":
            case "IcedTea":
            case "IcedMilkTea":
            case "IcedGreen":
            case "IcedGreenLatte":
            case "IcedChocolate":
            case "IcedChocoLatte":
                return "GlassCup";

            case "BlackTea":
            case "MilkTea":
            case "SweetAndSour":
            case "RussianTea":
            case "ChaiAdeni":
            case "JustGreen":
            case "JustMilk":
            case "HoneyMilk":
                return "TeaCup";

            default:
                return "";
        }
    }
    
    private void CupReady()
    {
        cup = CheckCup();
        GameObject newcup = Resources.Load("cup/" + cup) as GameObject;
        Transform brewMat = ObjectManager.Instance.brewMat.transform;
        Instantiate(newcup, brewMat.position, brewMat.rotation);
    }
    
    public void RecipeDone()
    {
        Debug.Log("¿Ï¼º!");
    }
}
