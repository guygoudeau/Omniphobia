///<summary>
///This script is for playing a sound when the AnimationEvent FootDown happens.
///This script requires an AudioSource with an audio clip attached and an ONSPAudioSource script attached to the GameObject.
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ONSPAudioSource))]
public class WalkingEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //AnimationEvent Function
    public void FootDown()
    {
        GetComponent<AudioSource>().Play();
    }
}
