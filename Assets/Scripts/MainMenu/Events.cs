///<summary>
/// Before adding or removing any events ask Dylan
/// </summary>

using UnityEngine.Events;

public static class Events
{
    public static PlayerEvent PlayerWin = new PlayerEvent();
    public static PlayerEvent PlayerDeath = new PlayerEvent();
    public static PlayerEvent PlayerForceScene = new PlayerEvent();    

    public static RoomEvent RoomCompleted = new RoomEvent();
    public static RoomEvent RoomHeightSelected = new RoomEvent();
    public static RoomEvent RoomSpiderSelected = new RoomEvent();
    public static RoomEvent RoomDollSelected = new RoomEvent();
    public static RoomEvent RoomClownSelected = new RoomEvent();

    public static GameEvent GameRestarted = new GameEvent();
    public static GameEvent GameStarted = new GameEvent();
}

public class PlayerEvent : UnityEvent
{
}


public class RoomEvent : UnityEvent
{
}

public class GameEvent : UnityEvent
{
}