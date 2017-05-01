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
    //private float Changes;
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
        //float HandDifference = L_Hand.transform.position.y - R_Hand.transform.position.y;

        if (active)
        {
            //Changes = 0.1f * (HandDifference);

            //Mathf.Clamp(Changes, 0, 0.8f);

            Player.gameObject.transform.rotation.Set(
                Player.gameObject.transform.rotation.x, Player.gameObject.transform.rotation.y, Head.transform.rotation.z * offSet, Player.gameObject.transform.rotation.w);
        }
    }
}
