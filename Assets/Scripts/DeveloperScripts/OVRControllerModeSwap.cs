using UnityEngine;
using System;

public class OVRControllerModeSwap : MonoBehaviour
{
    private void Start()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            GetComponent<OVRPlayerController>().NotUsingOVC = true;            
        }
        else
        {
            GetComponent<OVRPlayerController>().NotUsingOVC = false;
        }
    }
}
