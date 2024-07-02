using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HSJ
{
    [Serializable]
    public class Data
    {
        public PlayerData playerData;
        public List<CustomerData> customerData;
    }

    public class DataManager : Singleton<DataManager>
    {
        [field: SerializeField]
        public Data data { get; private set; } = new Data();

        private string GetPath(int slot)
        {
            return Path.Combine(Application.persistentDataPath, $"Data{slot}.json");
            
        }

        public void Save(int slot = 0)
        {
            // 저장용 클래스를 JSON 형식으로 변환
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);

            // 파일로 저장
            string path = GetPath(slot);
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                streamWriter.WriteLine(jsonString);
            }
        }

        public Data Load(int slot)
        {
            // 저장된 파일이 있다면
            string path = GetPath(slot);
            if (File.Exists(path))
            {
                // 저장된 파일 읽어오기
                using (StreamReader streamReader = new StreamReader(path))
                {
                    // JSON 형식으로 저장된 파일을 클래스 형태로 변환
                    var jsonString = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Data>(jsonString);
                }
            }

            return null;
        }
    }
}
