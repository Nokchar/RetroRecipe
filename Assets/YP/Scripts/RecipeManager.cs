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
            foreach (var mix in mixture) // ����ڰ� ���� ���� �� �ϳ�
            {
                result = false;
                foreach (var dataMix in recipes[order]) // �������� ���� �� �ϳ�
                {
                    if (mix == dataMix) // ����� ���� ������ ��� ��
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



        Debug.Log("�޴� �̸���" + order);
        return order;
    }
}
