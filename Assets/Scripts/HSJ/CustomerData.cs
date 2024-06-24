using System.Collections.Generic;
using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class CustomerData : ScriptableObject
    {
        public string customerName;
        public int exp;
        public int visitCount;
        public List<Gift> gifts;
        public List<AudioClip> talks;
        public List<AudioClip> reacts;
    }
}
