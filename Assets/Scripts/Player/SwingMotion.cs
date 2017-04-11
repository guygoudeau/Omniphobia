using UnityEngine;
using System.Collections;

public class SwingMotion : MonoBehaviour
{
    public Vector3 lTouchVelocity;
    public Vector3 rTouchVelocity;

	void Update()
    {
        lTouchVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).normalized;
        rTouchVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).normalized;

        while (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            transform.forward += lTouchVelocity;
            transform.forward += rTouchVelocity;
        }
    }
}