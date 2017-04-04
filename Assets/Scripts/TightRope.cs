using UnityEngine;
using System.Collections;

public class TightRope : MonoBehaviour {

    public OVRPlayerController Player;
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
            active = true;
    }

    void OnTriggerExit(Collider other)
    {
        Player.gameObject.transform.rotation =
            new Quaternion(Player.gameObject.transform.rotation.x,
                Player.gameObject.transform.rotation.y, 0, Player.gameObject.transform.rotation.w);
        active = false;
    }

    void Update()
    {
        float HandDifference = L_Hand.transform.position.y - R_Hand.transform.position.y;

        if (active)
        {
            Changes = 0.1f /** Time.deltaTime*/ * (HandDifference /*+ 0.4f*/);

            Mathf.Clamp(Changes, 0, 0.8f);

            Player.gameObject.transform.rotation = 
                new Quaternion(Player.gameObject.transform.rotation.x,
                Player.gameObject.transform.rotation.y, Player.gameObject.transform.rotation.z + Changes, Player.gameObject.transform.rotation.w);
        }
    }
}
