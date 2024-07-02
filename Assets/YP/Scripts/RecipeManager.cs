using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager instance;
    public static RecipeManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<RecipeManager>();

                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    GameObject newObj = new GameObject();
                    newObj.AddComponent<RecipeManager>();

                    instance = newObj.GetComponent<RecipeManager>();
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

    public List<string> RecipeFinder(string order)
    {
        var recipes = CSVManager.Instance.recipes;
        List<string> list = new List<string>();

        foreach (var dataMix in recipes[order])
        {
            list.Add(dataMix);
        }
        return list;
    }

    public string MixtureFinder(List<string> mixture, string order)
    {
        var recipes = CSVManager.Instance.recipes;
        bool result;

        Debug.Log(recipes[order].Count);
        Debug.Log(mixture.Count);

        if (recipes[order].Count == mixture.Count)
        {
            foreach (var mix in mixture) // 사용자가 넣은 재료들 중 하나
            {
                result = false;
                foreach (var dataMix in recipes[order]) // 레시피의 재료들 중 하나
                {
                    if (mix == dataMix) // 사용자 재료와 레시피 재료 비교
                    {
                        result = true;
                    }
                }

                if (!result)
                {
                    Debug.Log("other1");
                    return "other";
                }
            }
        }
        else
        {
            Debug.Log("other2");
            return "other";
        }



        Debug.Log("메뉴 이름은" + order);
        return order;
    }
}
