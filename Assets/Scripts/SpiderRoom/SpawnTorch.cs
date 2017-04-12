using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnTorch : MonoBehaviour {


    public Transform Player;
    public bool Grabbed;
    public bool spawnState;
	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<CharacterController>().GetComponent<Transform>();
        Grabbed = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            transform.position = (Player.position + Player.forward);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            spawnState = true;
            Grabbed = false;
        }

        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed == true)
        {
            Grabbed = true;
        }
     if (Grabbed == true)
        {
            spawnState = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            transform.position = gameObject.GetComponent<OVRGrabbable>().grabbedBy.transform.position;
        }
        else
        {
            if (spawnState == false)
            {
                Grabbed = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
       

    }
}
