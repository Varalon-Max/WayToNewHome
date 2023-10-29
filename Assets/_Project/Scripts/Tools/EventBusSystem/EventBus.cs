using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Tools.EventBusSystem
{
    public static class EventBus<T> where T : IEvent
    {
        private static readonly HashSet<IEventBinding<T>> Bindings = new();

        public static void Register(EventBinding<T> binding)
        {
            Bindings.Add(binding);
        }
        public static void Deregister(EventBinding<T> binding)
        {
            Bindings.Add(binding);
        }

        public static void Raise(T @event)
        {
            foreach (var eventBinding in Bindings)
            {
                eventBinding.OnEvent.Invoke(@event);
                eventBinding.OnEventNoArgs.Invoke();
            }
        }

        private static void Clear()
        {
            Debug.Log($"Clearing {typeof(T).Name} bindings");
        }
    }
}