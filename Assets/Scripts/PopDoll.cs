using UnityEngine;
using System.Collections;

public class PopDoll : MonoBehaviour {

    private GameObject _player;
    private GameObject _parent;
    private bool _popped;

    public Vector3 _force;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("OVRPlayerController");
        _parent = transform.parent.gameObject;
        _force = _parent.transform.forward * 8;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!_popped)
        {
            if (other.name == _player.name)
            {
                _parent.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);
                _popped = true;
            }
        }
    }
}
