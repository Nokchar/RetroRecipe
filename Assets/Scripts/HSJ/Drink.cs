using System.Collections.Generic;
using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class Drink : ScriptableObject
    {
        public enum DrinkType
        {
            Latte,
            Cocoa,
        };
        public DrinkType type;
        public List<Item> items;
    }
}
