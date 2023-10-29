namespace _Project.Scripts.Tools.EventBusSystem
{
    public interface IEvent
    {
    }

    public struct TestEvent : IEvent
    {
    }

    public struct InputEvent : IEvent
    {
        public float X;
    }
}