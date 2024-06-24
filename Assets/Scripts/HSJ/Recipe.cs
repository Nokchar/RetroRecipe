using System.Collections.Generic;
using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class Recipe : ScriptableObject
    {
        public enum RecipeType
        {
            Food,
            Drink
        };
        public RecipeType type;
        public List<Food> Foods;
        public List<Drink> Drinks;
    }
}
