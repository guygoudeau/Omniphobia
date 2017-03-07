using UnityEngine;
using System.Collections;

public class AudioClipTrigger : MonoBehaviour {

    private GameObject _footsteps;
    private int _type = 0;

	// Use this for initialization
	void Start () {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.name == "Footsteps")
            {
                _footsteps = go;
            }
        }

        if (name.Contains("Regular"))
            _type = 0;

        else if (name.Contains("Wood"))
            _type = 1;

        else if (name.Contains("Glass"))
            _type = 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "OVRPlayerController")
        {
            _footsteps.GetComponent<WalkingSound>().CurrentClip = _type;
        }
    }
}
