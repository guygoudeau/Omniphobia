using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkingSound : MonoBehaviour
{
    GameObject _player;
    GameObject _self;
    Vector3 _prevPosition;
    List<AudioSource> steps = new List<AudioSource>();
    public GameObject GlassPrefab;
    public bool GlassReady;
    public float Timer = 5;
    public float Distance;
    public int CurrentClip = 0;

    // Use this for initialization
    void Start()
    {
        if (_player == null)
        {
            _player = GameObject.Find("OVRPlayerController");
            _self = this.gameObject;
        }

        _prevPosition = _player.transform.position;
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 1.05f, _player.transform.position.z);
        foreach (AudioSource AS in _self.GetComponents<AudioSource>())
        {
            steps.Add(AS);
        }
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
        //Debug.Log(steps[CurrentClip].clip);
        if (_prevPosition != _player.transform.position && _player.GetComponent<CharacterController>().isGrounded)
        {
            if (!(_player.GetComponent<CharacterController>().velocity.x == 0) && !(_player.GetComponent<CharacterController>().velocity.z == 0))
            {
                if (!(steps[CurrentClip].isPlaying))
                {
                    if (Distance >= 1)
                    {
                        steps[CurrentClip].Play();
                        //Part of the Timer
                        if (Timer == 5 && CurrentClip == 2)
                        {
                            GameObject NewBreak = Instantiate(GlassPrefab, _player.transform) as GameObject;
                            NewBreak.transform.parent = null;
                            NewBreak.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 1.05f, _player.transform.position.z);
                            steps[3].Play();
                            GlassReady = false;
                        }
                        Distance = 0;
                    }
                }
            }
            Distance += Mathf.Abs(_player.transform.position.magnitude - _prevPosition.magnitude);
            _prevPosition = _player.transform.position;
        }
    }
}
