using UnityEngine;
using System.Collections;

public class SwingMotion : MonoBehaviour
{
    public float lTouchVelocity;
    public float rTouchVelocity;
    public float speedMod;

	void Update()
    {
        lTouchVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;
        rTouchVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;

        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            Debug.Log("The GameObject:" + name + " needs a rigidbody");
            return;
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            rigidbody.velocity = transform.forward * (lTouchVelocity + rTouchVelocity) * (speedMod);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}