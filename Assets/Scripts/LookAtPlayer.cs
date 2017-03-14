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
            var PosDiff = transform.position - _player.transform.position;
            Quaternion TargetRot = Quaternion.LookRotation(PosDiff);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, new Quaternion(0, TargetRot.y, 0, TargetRot.w), Time.deltaTime * 0.5f);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime);
        }
        IsVisible = this.gameObject.GetComponent<MeshRenderer>().isVisible;

    }
}
