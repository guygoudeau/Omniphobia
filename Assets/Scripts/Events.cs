using UnityEngine.Events;

public static class Events
{
    public static PlayerEvent PlayerWin = new PlayerEvent();
    public static PlayerEvent PlayerDeath = new PlayerEvent();
    public static PlayerEvent PlayerReloadScene = new PlayerEvent();
    public static PlayerEvent PlayerForceScene = new PlayerEvent();
}

public class PlayerEvent : UnityEvent
{
}
