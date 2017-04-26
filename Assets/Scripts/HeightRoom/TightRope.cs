///<summary>
///Used to simulate balencing on a tightrope in VR.
///</summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class TightRope : MonoBehaviour {

    public float offSet;
    private OVRPlayerController Player;
    public bool active;
    public GameObject Head;
    private Quaternion Rotation;

    void Start()
    {
        active = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject.GetComponent<OVRPlayerController>();
            Rotation = Player.gameObject.transform.rotation;
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Player.gameObject.transform.rotation = Rotation;
        active = false;
    }

    void Update()
    {
        if (active)
        {
            Player.gameObject.transform.rotation.Set(
            Player.gameObject.transform.rotation.x, Player.gameObject.transform.rotation.y, Head.transform.rotation.z * offSet, Player.gameObject.transform.rotation.w);
        }
    }
}
