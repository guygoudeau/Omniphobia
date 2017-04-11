using UnityEngine;
using System.Collections;

public class SwingMotion : MonoBehaviour
{
    public float lTouchVelocity;
    public float rTouchVelocity;

	void Update()
    {
        lTouchVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;
        rTouchVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;

        while (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            transform.position += transform.forward * lTouchVelocity * Time.deltaTime;
            transform.position += transform.forward * rTouchVelocity * Time.deltaTime;
        }
    }
}