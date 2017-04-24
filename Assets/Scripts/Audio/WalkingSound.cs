///<summary>
///This script exists to play audio clips for walking and stays at the players feet for the 3D audio sounds appropriate.
///This script does so by having multiple audio sources and putting them into a list. It then makes a raycast downward to check the tag of the floor/ground after a certain
///     distance is traversed and if the player is ground. Afterwards it selects the appropriate clip based on the tag and then plays the clip.
///This script requires the ONSP Audio Source script and at least one audio source attached to the GameObject to work properly.
///This script also requires that an OVRPlayerController exist in the scene.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ONSPAudioSource))]
[RequireComponent(typeof(AudioSource))]
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
            _player = GameObject.FindGameObjectWithTag("Player");
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
        transform.rotation = _player.transform.rotation;
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
            if (Distance >= 2f)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position + transform.forward + new Vector3(0, 1, 0), new Vector3(0, -1, 0), out hit, 2f))
                        {
                            if (hit.transform.tag.Contains("Furnitured"))
                                CurrentClip = 0;
                            else if (hit.transform.tag.Contains("Wood"))
                                CurrentClip = 1;
                            else if (hit.transform.tag.Contains("Glass"))
                                CurrentClip = 2;
                            else if (hit.transform.tag.Contains("Regular"))
                                CurrentClip = 4;
                        }
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
            float a = Mathf.Abs(_player.transform.position.x - _prevPosition.x);
            float b = Mathf.Abs(_player.transform.position.z - _prevPosition.z);
            float c = Mathf.Sqrt((a * a) + (b * b));
            Distance += c;
            _prevPosition = _player.transform.position;
        }
    }
}
