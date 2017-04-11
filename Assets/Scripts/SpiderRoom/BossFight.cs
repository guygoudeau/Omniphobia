using UnityEngine;
using System.Collections;

public class BossFight : MonoBehaviour {


    GameObject Player;

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
    void Update()
    {

    }
}
