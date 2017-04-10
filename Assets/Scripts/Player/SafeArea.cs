using UnityEngine;
using System.Collections;

public class SafeArea : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerStateSystem>())
        {
            Events.PlayerCantDie.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStateSystem>())
        {
            Events.PlayerCanDie.Invoke();
        }
    }
}
