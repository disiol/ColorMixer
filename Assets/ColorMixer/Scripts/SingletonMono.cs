using UnityEngine;

namespace ColorMixer.Scripts
{
    public class SingletonMono<T> : MonoBehaviour where T:MonoBehaviour
    {
        private static T instacne;

        public static T Instance
        {
            get
            {
                if (Application.isPlaying)
                {
                    if (instacne == null)
                    {
                        instacne = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    }
                }
                return instacne;
            }
        }
        public static T GetCurrentInstance()
        {
            return instacne;
        }


    }
}