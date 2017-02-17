using UnityEngine;
using System.Collections;

public class InteractiveLook : MonoBehaviour {

    private GameObject _player;
    public Transform _self;

	// Use this for initialization
	void Start () {
        if (_player == null)
        {
            foreach (GameObject go in FindObjectsOfType<GameObject>())
            {
                if (go.name == "OVRPlayerController")
                {
                    _player = go;
                }
                else if (go.name == "First Person Controller")
                {
                    _player = go;
                }
                else if (go.name == "Footsteps")
                {
                    _self = go.transform;
                }
            }
        }
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = _player.transform.TransformDirection(Vector3.forward);
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);
        if(Physics.Raycast(_self.position,fwd,3))
        {

        }
    }
}
