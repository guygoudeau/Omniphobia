using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

    private GameObject _player;
    private Transform _targetTransform;
    public bool IsVisible = false;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("OVRPlayerController");
        foreach(Transform tf in transform.parent.GetComponentInChildren<Transform>())
        {
            if(tf.name == "Target")
            {
                _targetTransform = tf;
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        _targetTransform.LookAt(_player.transform);
        if (this.gameObject.GetComponent<MeshRenderer>().isVisible)
        {
            Quaternion TargetRot = _targetTransform.localRotation;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, new Quaternion(0, TargetRot.y, 0, TargetRot.w), Time.deltaTime * 0.9f);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime);
        }
        IsVisible = this.gameObject.GetComponent<MeshRenderer>().isVisible;

    }
}
