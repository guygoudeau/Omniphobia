///<summary>
///This script causes the attached GameObject to be launched by a Force once the OVRPlayerController enters the Box Collider component of the attached GameObject.
///This script requires to be attached to a GameObject with a BoxCollider to detect if the player enters the BoxCollider's area.
///This script also requires to have the attached GameObject be parented to another GameObject.
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PopDoll : MonoBehaviour {

    private GameObject _player;
    private GameObject _parent;
    private bool _popped;

    public Vector3 _force;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("OVRPlayerController");
        //The script needs to be applied to a child object for the purpose having a separate collider for the trigger
        _parent = transform.parent.gameObject;
        _force = _parent.transform.forward * 8 + _parent.transform.up * 1;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        //If statement that prevents the contained code from performing should the boolean equal true
        if (!_popped)
        {
            //If statement that checks to see of the colliding object is the player
            if (other.name == _player.name)
            {
                _parent.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);
                _popped = true;
            }
        }
    }
}
