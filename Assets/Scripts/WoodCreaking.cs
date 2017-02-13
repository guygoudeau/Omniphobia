using UnityEngine;
using System.Collections;

public class WoodCreaking : MonoBehaviour {

    private Vector3 _playerHeight = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
        if(other.collider.name == "First Person Controller")
        {
            Debug.Log("Player Walked Over Me");
            if(_playerHeight != other.collider.transform.position)
            {
                if(!(this.GetComponent<AudioSource>().isPlaying))
                {
                    this.GetComponent<AudioSource>().Play();
                }
                _playerHeight = other.collider.transform.position;
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.name == "First Person Controller")
        {
            Debug.Log("Player Is Stepping On Me");
            if (_playerHeight != other.collider.transform.position)
            {
                if (!(this.GetComponent<AudioSource>().isPlaying))
                {
                    this.GetComponent<AudioSource>().Play();
                }
                _playerHeight = other.collider.transform.position;
            }
        }
    }
}
