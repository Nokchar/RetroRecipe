using UnityEngine;

namespace HSJ
{
    [CreateAssetMenu]
    public class Gift : ScriptableObject
    {
        public enum GiftType
        {
            Gift0,
            Gift1,
            Gift2,
        };
        public GiftType type;
    }
}
