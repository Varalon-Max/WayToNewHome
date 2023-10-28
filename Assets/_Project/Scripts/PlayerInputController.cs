using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerInputController : MonoBehaviour
    {
        public static PlayerInputController Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
