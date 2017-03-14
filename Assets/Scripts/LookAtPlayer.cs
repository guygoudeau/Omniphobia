using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

    private GameObject _player;
    public bool IsVisible = false;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("OVRPlayerController");
    }
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.GetComponent<MeshRenderer>().isVisible)
        {
            Quaternion PreviousRot = transform.localRotation;
            transform.LookAt(_player.transform);
            Quaternion TargetRot = transform.localRotation;
            transform.localRotation = Quaternion.Slerp(PreviousRot, TargetRot, Time.deltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime);
        }
        IsVisible = this.gameObject.GetComponent<MeshRenderer>().isVisible;

    }
}
