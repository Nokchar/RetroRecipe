using UnityEngine;

namespace HSJ
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    // 초기화 전에 다른 인스턴스 확인
                    instance = FindObjectOfType<T>();

                    // 찾을 수 없다면 새로운 게임오브젝트를 생성
                    if (!instance)
                    {
                        GameObject go = new GameObject();
                        go.name = typeof(T).Name;
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        // 파생 클래스에서 재정의 가능
        public virtual void Awake()
        {
            // 인스턴스가 없는 경우
            if (!instance)
            {
                // 현재 오브젝트를 인스턴스로 설정
                instance = this as T;

                // 새로운 씬이 로드됐을 때 현재 오브젝트를 유지
                DontDestroyOnLoad(gameObject);
            }
            // 이미 존재하는 경우
            else
            {
                // 복제를 막기 위해 스스로를 제거
                Destroy(gameObject);
            }
        }
    }
}
