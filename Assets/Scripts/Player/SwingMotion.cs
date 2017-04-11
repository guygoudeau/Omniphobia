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

    }
}