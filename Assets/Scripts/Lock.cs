using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Key"))
        {
            StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(1));
        }
    }
}
