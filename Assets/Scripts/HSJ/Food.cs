using System.Collections.Generic;
using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class Food : ScriptableObject
    {
        public enum FoodType
        {
            ApplePie,
            Toast,
        };
        public FoodType type;
        public List<Item> items;
    }
}
