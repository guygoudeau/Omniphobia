using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkingSound : MonoBehaviour
{
    GameObject _player;
    GameObject _self;
    Vector3 _prevPosition;
    List<AudioSource> steps;
    public GameObject GlassPrefab;
    public bool GlassReady;
    public float Timer = 5;
    public float Distance;

    // Use this for initialization
    void Start()
    {
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
                    _self = go;
                }
            }
        }
        _prevPosition = _player.transform.position;
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 1.05f, _player.transform.position.z);
        //foreach(AudioSource AS in _self.GetComponents<AudioSource>())
        //{
        //    steps.Add(AS);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Part of the Timer
        if (GlassReady != true)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                GlassReady = true;
                Timer = 5;
            }
        }
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 1.05f, _player.transform.position.z);

        if (_prevPosition != _player.transform.position && _player.GetComponent<CharacterController>().isGrounded)
        {
            if (!(_self.GetComponent<AudioSource>().isPlaying))
            {
                if (Distance >= 1)
                {
                    _self.GetComponent<AudioSource>().Play();
                    //Part of the Timer
                    if (Timer == 5)
                    {
                        GameObject NewBreak = Instantiate(GlassPrefab, _player.transform) as GameObject;
                        NewBreak.transform.parent = null;
                        NewBreak.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 1.05f, _player.transform.position.z);
                        GlassReady = false;
                    }
                    Distance = 0;
                }
            }
            Distance += Mathf.Abs(_player.transform.position.magnitude - _prevPosition.magnitude);
            _prevPosition = _player.transform.position;
        }
        //Distance = _player.transform.position.magnitude - _prevPosition.magnitude;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "WoodCreaking")
    //    {
    //        if (_prevPosition != other.transform.position)
    //        {
    //            if (_player.GetComponent<CharacterController>().isGrounded)
    //            {
    //                if (!(steps[1].isPlaying))
    //                {
    //                    steps[1].Play();
    //                    Debug.Log("Player Stepped On Me");
    //                }
    //            }
    //            _prevPosition = other.transform.position;
    //        }
    //    }
    //}

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.name == "WoodCreaking")
    //    {
    //        Debug.Log("Steppin on the planks");
    //        if (_prevPosition != other.transform.position)
    //        {
    //            if (_player.GetComponent<CharacterController>().isGrounded)
    //            {
    //                if (!(steps[1].isPlaying))
    //                {
    //                    steps[1].Play();
    //                    Debug.Log("Player Is Stepping On Me");
    //                }
    //            }
    //            _prevPosition = other.transform.position;
    //        }
    //    }
    //}
}
