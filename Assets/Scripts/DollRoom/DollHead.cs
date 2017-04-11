///<summary>
///This script moves the Doll's head, turning it towards the player either when it is not in camera view or when it is in camera view.
///This script must be attached to the Doll's head which should be separate from the Doll Body.
///This script requires the player to exist with a GameObject called CenterEyeAnchor, and requires a GameObject that shares the same parent as the Doll head called Target.
///The Target GameObject is required to use the Transform.LookAt function to retrieve a Target Rotation for the Quaternion.Slerp function that will be used to
///     turn the Doll's head.
///</summary>
using UnityEngine;
using System.Collections;

public class DollHead : MonoBehaviour {

    private GameObject _player;
    private Transform _targetTransform;
    public bool SpyOnPlayer;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("CenterEyeAnchor");

        //Finds a specific child of the parent gameObject to set as the target transform.
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
        
        //An if statement that decides if the Doll will openly look at the player, or if the Doll will only look at the player if the Doll is not in Camera view.
        if (!SpyOnPlayer)
        {
            //If the Doll is visible, it's head will rotate to look at the player.
            if (this.gameObject.GetComponent<MeshRenderer>().isVisible)
            {
                Quaternion TargetRot = _targetTransform.localRotation;
                transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRot, Time.deltaTime * 0.9f);
            }
            else
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
            }
        }
        else
        {
            if (this.gameObject.GetComponent<MeshRenderer>().isVisible)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
            }
            else
            {
                Quaternion TargetRot = _targetTransform.localRotation;
                transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRot, Time.deltaTime);
            }
        }
    }
}
