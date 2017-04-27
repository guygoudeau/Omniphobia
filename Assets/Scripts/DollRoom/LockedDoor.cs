using UnityEngine;
using System.Collections.Generic;

public class LockedDoor : MonoBehaviour
{
    public List<Lock> Padlocks;
    bool isFirstKey;
	// Use this for initialization
	void Start ()
    {
        Events.LockUnlocked.AddListener(CheckLocks);
        isFirstKey = true;
	}
	
	void CheckLocks()
    {
        if (isFirstKey)
        {
            Events.SpawnClown.Invoke();
            isFirstKey = false;
        }
        foreach(var padlock in Padlocks)
        {
            if (padlock.isLocked)
                return;
        }
        Events.RoomCompleted.Invoke();
    }
}
