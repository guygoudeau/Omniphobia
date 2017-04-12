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
    private float _maxVelocity = 0;

    // Use this for initialization
    void Start() {
        _prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (GetComponent<Rigidbody>().velocity.magnitude >= 1)
        {
            if (_maxVelocity < GetComponent<Rigidbody>().velocity.magnitude)
                _maxVelocity = GetComponent<Rigidbody>().velocity.magnitude;
            _moving = true;
        }

        VelocityCap(GetComponent<Rigidbody>());
    }

    void OnCollisionEnter(Collision other)
    {
        if(_moving)
        {
            Debug.Log(_maxVelocity);
            GetComponent<AudioSource>().volume = _maxVelocity * .1f;
            GetComponent<AudioSource>().Play();
            _moving = false;
            _maxVelocity = 0;
        }
    }

    void VelocityCap(Rigidbody _object)
    {
        if (_object.velocity.magnitude > 10)
            _object.velocity.Normalize();
    }
}
