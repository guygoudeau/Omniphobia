using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= 0.9f)
            transform.position = new Vector3(-7.315f, 2.2f, 23.43f);
	}
}
