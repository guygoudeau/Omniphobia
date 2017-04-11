using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class DropThrow : MonoBehaviour {

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
            Debug.Log(GetComponent<AudioSource>().clip);
            GetComponent<AudioSource>().Play();
            _moving = false;
        }
    }

    void OnCollisionStay(Collision other)
    {

    }
}
