///<summary>
///Used to simulate balencing on a tightrope in VR.
///</summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class TightRope : MonoBehaviour {

    private OVRPlayerController Player;
    public bool active;
    private float Changes;
    public GameObject L_Hand;
    public GameObject R_Hand;

    void Start()
    {
        active = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject.GetComponent<OVRPlayerController>();
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Player.gameObject.transform.rotation =
            new Quaternion(0,
                0, 0, Player.gameObject.transform.rotation.w);
        active = false;
    }

    void Update()
    {
        float HandDifference = L_Hand.transform.position.y - R_Hand.transform.position.y;

        if (active)
        {
            Changes = 0.1f * (HandDifference);

            Mathf.Clamp(Changes, 0, 0.8f);

            Player.gameObject.transform.rotation = 
                new Quaternion(Player.gameObject.transform.rotation.x,
                Player.gameObject.transform.rotation.y, Player.gameObject.transform.rotation.z + Changes, Player.gameObject.transform.rotation.w);
        }
    }
}
