using UnityEngine;
using System.Collections;

public class AudioClipTrigger : MonoBehaviour {

    private GameObject footsteps = new GameObject();

	// Use this for initialization
	void Start () {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.name == "Footsteps")
            {
                footsteps = go;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

    }
}
