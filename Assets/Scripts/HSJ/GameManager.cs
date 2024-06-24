using UnityEngine;

namespace HSJ
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject player;
        
        private void Start()
        {
            DontDestroyOnLoad(player);
        }
    }
}
