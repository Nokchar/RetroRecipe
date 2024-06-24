using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public enum ItemType
        {
            Apple,
            Bacon,
            Egg,
            Lettuce,
            Water,
            Ice,
            Coffee,
            Milk,
            Sugar,
            Cream,
            Honey,
        };
        public ItemType type;
    }
}
