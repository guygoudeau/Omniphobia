using UnityEngine;
using System.Collections;

public class BossFight : MonoBehaviour {


    GameObject Player;
    public Transform Cheat;
    public Transform Begin;
	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<CharacterController>().gameObject ;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.GetComponent<CharacterController>())
        {
            Events.RoomCompleted.Invoke();
        }
    }
    // Update is called once per frame
    void Update () {
        if (OVRInput.GetDown(OVRInput.Button.Four))
            {
            Player.transform.position = Cheat.position;
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                Player.transform.position = Begin.position;
            }
            }
	
	}
}
