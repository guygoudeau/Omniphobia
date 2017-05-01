///<summary>
///This script causes the attached GameObject to be launched by a Force once the OVRPlayerController enters the Box Collider component of the attached GameObject.
///This script requires to be attached to a GameObject with a BoxCollider to detect if the player enters the BoxCollider's area.
///This script also requires to have the attached GameObject be parented to another GameObject that also contains another child GameObject with the DollHead script attached.
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PopDoll : MonoBehaviour {

    private GameObject _player;
    private GameObject _parent;
    private bool _popped;

    public bool movingDoll = false;
    public Vector3 force;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        //The script needs to be applied to a child object for the purpose having a separate collider for the trigger
        _parent = transform.parent.gameObject;
        force = _parent.transform.forward * 8 + _parent.transform.up * 1;
        movingDoll = false;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!movingDoll)
            force = _parent.GetComponentInChildren<DollHead>().transform.forward * 8 + _parent.transform.up * 1;

        //If statement that prevents the contained code from performing should the boolean equal true
        if (!_popped)
        {
            //If statement that checks to see of the colliding object is the player
            if (other.tag == _player.tag)
            {
                _parent.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                _popped = true;
            }
        }
    }
}
