///<summary>
///This script exists to play an audio clip when an object moves at a velocity magnitude equal to or higher than 1 and collides with another object.
///This script does so by checking the velocity magnitude in the Update function to see if the velocity magnitude is equal to or greater than 1. If it is, a boolean is set to
///     true. In the OnCollisionEnter function, it checks to see if the boolean is true. When it is true, it plays the AudioSource.
///This script requires the object to have the ONSPAudioSource script, a singular AudioSource, and a Rigidbody.
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ONSPAudioSource))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class CollisionSound : MonoBehaviour {

    private Vector3 _prevPosition;
    private bool _moving = false;

    // Use this for initialization
    void Start() {
        _prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (GetComponent<Rigidbody>().velocity.magnitude >= 1)
            _moving = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if(_moving)
        {
            GetComponent<AudioSource>().Play();
            _moving = false;
        }
    }

    void OnCollisionStay(Collision other)
    {

    }
}
