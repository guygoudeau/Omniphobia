using UnityEngine;
using System.Collections.Generic;

public class LockedDoor : MonoBehaviour
{
    public List<Lock> Padlocks;    
	// Use this for initialization
	void Start ()
    {
        Events.LockUnlocked.AddListener(CheckLocks);
	}
	
	void CheckLocks()
    {
        foreach(var padlock in Padlocks)
        {
            if (padlock.isLocked)
                return;
        }
        Events.RoomCompleted.Invoke();
    }
}
