using System.Collections.Generic;
using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        public string playerName;
        public int exp;
        public float time;
        public List<Recipe> recipes;
        public List<Gift> gifts;
    }
}
