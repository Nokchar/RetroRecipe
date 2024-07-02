using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    private static CSVManager instance;
    public static CSVManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<CSVManager>();

                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    GameObject newObj = new GameObject();
                    newObj.AddComponent<CSVManager>();

                    instance = newObj.GetComponent<CSVManager>();
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

    [NonSerialized] public Dictionary<string, List<string>> recipes = new Dictionary<string, List<string>>();
    [NonSerialized] public Dictionary<string, List<string>> cstmrs = new Dictionary<string, List<string>>();

    void Start()
    {
        LoadCSVtoDict("YP/DataFiles/RetroRecipe", recipes);
        LoadCSVtoDict("YP/DataFiles/CstmrShort", cstmrs);
    }

    private void LoadCSVtoDict(string filepath, Dictionary<string, List<string>> lists)
    {
        TextAsset csvData = Resources.Load(filepath) as TextAsset;
        using (StringReader sr = new StringReader(csvData.text))
        {
            string headerline = sr.ReadLine();
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');

                string Name = values[0];
                List<string> items = new List<string>();

                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        items.Add(values[i]);
                    }
                }
                if (!lists.ContainsKey(Name))
                {
                    lists[Name] = new List<string>();
                }
                lists[Name].AddRange(items);
            }

        }
    }

}
