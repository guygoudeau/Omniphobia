using UnityEngine;
using System.Collections;

public class WoodCreaking : MonoBehaviour {

    private Vector3 _prevPosition = new Vector3(0,0,0);
    GameObject _player;
    GameObject _self;
    GameObject _parent;

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
            }
        }
        _self = this.gameObject;
        _parent = this.transform.parent.gameObject;
        _self.transform.localPosition = _parent.GetComponent<BoxCollider>().center;
        _self.transform.localPosition = new Vector3(_self.transform.localPosition.x, _self.transform.localPosition.y + 15f, _self.transform.localPosition.z);
        _self.transform.localScale = _parent.GetComponent<BoxCollider>().size;
        Debug.Log(_self.name);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == _player.name)
        {
            if(_prevPosition != other.transform.position)
            {
                if (_player.GetComponent<CharacterController>().isGrounded)
                {
                    if (!(_self.GetComponent<AudioSource>().isPlaying))
                    {
                        _self.GetComponent<AudioSource>().Play();
                        Debug.Log("Player Stepped On Me");
                    }
                }
                _prevPosition = other.transform.position;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == _player.name)
        {
            if (_prevPosition != other.transform.position)
            {
                if (_player.GetComponent<CharacterController>().isGrounded)
                {
                    if (!(_self.GetComponent<AudioSource>().isPlaying))
                    {
                        _self.GetComponent<AudioSource>().Play();
                        Debug.Log("Player Is Stepping On Me");
                    }
                }
                _prevPosition = other.transform.position;
            }
        }
    }
}
