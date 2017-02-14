using UnityEngine;
using System.Collections;

public class WalkingSound : MonoBehaviour {
    GameObject _player;
    GameObject _self;
    Vector3 _prevPosition;
	// Use this for initialization
	void Start () {
        if(_player == null)
        {
            foreach(GameObject go in FindObjectsOfType<GameObject>())
            {
                if (go.name == "First Person Controller")
                {
                    _player = go;
                }
                else if(go.name == "Footsteps")
                {
                    _self = go;
                }
            }
        }
        _prevPosition = _player.transform.position;
        transform.position = _player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = _player.transform.position;

        if(_prevPosition != _player.transform.position)
        {
            if (!(_self.GetComponent<AudioSource>().isPlaying))
            {
                _self.GetComponent<AudioSource>().Play();
            }
            _prevPosition = _player.transform.position;
        }

        //else if(_prevPosition == _player.transform.position)
        //{
        //    if (this.GetComponent<AudioSource>().isPlaying)
        //    {
        //        this.GetComponent<AudioSource>().Stop();
        //    }
        //}
	}
}
