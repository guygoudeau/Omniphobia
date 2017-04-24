using UnityEngine;
using System.Collections;

public class PlayerStateChanges : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Events.PlayerMovementChange.Invoke();
        }        
    }
}
