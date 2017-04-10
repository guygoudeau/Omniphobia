using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateSystem>())
            Events.PlayerEnteredKillBox.Invoke();
    }
}
