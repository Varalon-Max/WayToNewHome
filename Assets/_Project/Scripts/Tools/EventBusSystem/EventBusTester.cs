using System;
using UnityEngine;

namespace _Project.Scripts.Tools.EventBusSystem
{
    public class EventBusTester : MonoBehaviour
    {
        private EventBinding<TestEvent> testEventBinding;
        private EventBinding<InputEvent> inputEventBinding;

        private void OnEnable()
        {
            testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
            EventBus<TestEvent>.Register(testEventBinding);

            inputEventBinding = new EventBinding<InputEvent>(HandleInputEvent);
            EventBus<InputEvent>.Register(inputEventBinding);
        }

        private void OnDisable()
        {
            EventBus<TestEvent>.Deregister(testEventBinding);
            EventBus<InputEvent>.Register(inputEventBinding);
        }

        private void HandleTestEvent()
        {
            Debug.Log("Test event received");
        }

        private void HandleInputEvent(InputEvent inputEvent)
        {
            Debug.Log($"Input event received: {inputEvent.X}");
        }
    }
}