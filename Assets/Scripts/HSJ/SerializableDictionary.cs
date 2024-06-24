using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HSJ
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        public List<TKey> keys;
        public List<TValue> values;

        public SerializableDictionary()
        {
            keys = new List<TKey>();
            values = new List<TValue>();
            SyncInspectorFromDictionary();
        }

        // 새로운 KeyValuePair를 추가하며, 인스펙터도 업데이트
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            SyncInspectorFromDictionary();
        }

        // KeyValuePair를 삭제하며, 인스펙터도 업데이트
        public new void Remove(TKey key)
        {
            base.Remove(key);
            SyncInspectorFromDictionary();
        }

        public void OnBeforeSerialize()
        {
        }

        // 인스펙터를 딕셔너리로 초기화
        public void SyncInspectorFromDictionary()
        {
            // 인스펙터 키 밸류 리스트 초기화
            keys.Clear();
            values.Clear();

            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        // 딕셔너리를 인스펙터로 초기화
        public void SyncDictionaryFromInspector()
        {
            // 딕셔너리 키 밸류 리스트 초기화
            foreach (var key in Keys.ToList())
            {
                base.Remove(key);
            }

            for (int i = 0; i < keys.Count; i++)
            {
                // 중복된 키가 있다면 에러 출력
                if (ContainsKey(keys[i]))
                {
                    Debug.LogError("Duplicate key found.");
                    break;
                }
                base.Add(keys[i], values[i]);
            }
        }

        public void OnAfterDeserialize()
        {
            Debug.Log($"Inspector key count: {keys.Count} value count: {values.Count}");

            // 인스펙터의 키 밸류가 KeyValuePair 형태를 띌 경우
            if (keys.Count == values.Count)
            {
                SyncDictionaryFromInspector();
            }
        }
    }
}
