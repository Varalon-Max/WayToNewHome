using System;
using _Project.Scripts.Tools.EventBusSystem;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                EventBus<TestEvent>.Raise(new TestEvent());
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                EventBus<InputEvent>.Raise(new InputEvent {X = 1f});
            }
        }
    }
}
