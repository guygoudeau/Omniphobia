using UnityEngine;
using System.Collections;

public class TightRope : MonoBehaviour {

    public OVRPlayerController Player;
    public bool active;
    private float RotationAmount;
    private float Changes;
    public float direction;

    void Start()
    {
        active = false;
        direction = -1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.gameObject)
        {
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player.gameObject)
        {
            active = false;
        }
    }

    void Update()
    {
        if (active)
        {
            Changes = 0.1f * Time.deltaTime * direction;

            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) != new Vector2(0, 0))
            {
                Changes *= OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
            }

            if (Player.gameObject.transform.rotation.z != 0)
            {
                direction = Player.gameObject.transform.rotation.z / Mathf.Abs(Player.gameObject.transform.rotation.z);
            }

            Player.gameObject.transform.rotation = 
                new Quaternion(Player.gameObject.transform.rotation.x,
                Player.gameObject.transform.rotation.y, Player.gameObject.transform.rotation.z + Changes, Player.gameObject.transform.rotation.w);
        }
    }
}
