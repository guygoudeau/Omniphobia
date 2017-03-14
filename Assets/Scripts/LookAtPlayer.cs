using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

    private GameObject _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("OVRPlayerController");
    }
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.GetComponent<MeshRenderer>().isVisible)
        {
            //Quaternion targetRot = Quaternion.Euler(_player.)
            transform.LookAt(_player.transform);
        }

	}
}
