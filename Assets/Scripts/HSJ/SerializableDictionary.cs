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

        // ���ο� KeyValuePair�� �߰��ϸ�, �ν����͵� ������Ʈ
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            SyncInspectorFromDictionary();
        }

        // KeyValuePair�� �����ϸ�, �ν����͵� ������Ʈ
        public new void Remove(TKey key)
        {
            base.Remove(key);
            SyncInspectorFromDictionary();
        }

        public void OnBeforeSerialize()
        {
        }

        // �ν����͸� ��ųʸ��� �ʱ�ȭ
        public void SyncInspectorFromDictionary()
        {
            // �ν����� Ű ��� ����Ʈ �ʱ�ȭ
            keys.Clear();
            values.Clear();

            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        // ��ųʸ��� �ν����ͷ� �ʱ�ȭ
        public void SyncDictionaryFromInspector()
        {
            // ��ųʸ� Ű ��� ����Ʈ �ʱ�ȭ
            foreach (var key in Keys.ToList())
            {
                base.Remove(key);
            }

            for (int i = 0; i < keys.Count; i++)
            {
                // �ߺ��� Ű�� �ִٸ� ���� ���
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

            // �ν������� Ű ����� KeyValuePair ���¸� �� ���
            if (keys.Count == values.Count)
            {
                SyncDictionaryFromInspector();
            }
        }
    }
}
