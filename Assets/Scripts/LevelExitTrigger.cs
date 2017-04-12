///<summary>
///Attach this script to any object that has a collider that is a trigger
///and this will invoke the room completed event
///</summary>
using UnityEngine;
using System.Collections;

public class LevelExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerStateSystem>())
        {
            Events.RoomCompleted.Invoke();
        }
    }
}
