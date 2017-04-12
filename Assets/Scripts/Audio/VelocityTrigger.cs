///<summary>
///This script exists to play an audio clip once after the object has a velocity.
///This script does so by first setting up the Object's AudioSource & ONSPAudioSource. Then it checks to see if the Object has a rigidbody and if a bool is false, which it should
///     be at the start. If the GameObject has a rigidbody, it will start checking the rigidbody's velocity. If the velocity is above 0, then it plays the AudioClip and sets the
///     boolean variable of the class to true, so that the sound cannot be played again.
///This script requires an AudioSource, an ONSPAudioSource, and if you want the audio to play, it requires a Rigidbody, but it is not as essential as the previous two
///     requirements.
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ONSPAudioSource))]
public class VelocityTrigger : MonoBehaviour
{

    private AudioSource _audio;
    private bool _soundPlayed = false;
    private ONSPAudioSource _audioRange;

    // Use this for initialization
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.spatialize = true;
        _audio.spatialBlend = 1;
        _audio.playOnAwake = false;

        _audioRange = GetComponent<ONSPAudioSource>();
        _audioRange.Far = 50;
        _audioRange.Near = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>() != null && !_soundPlayed)
        {
            if (GetComponent<Rigidbody>().velocity.magnitude > 0)
            {
                _audio.Play();
                _soundPlayed = true;
            }
        }
    }
}
