using UnityEngine;
using System.Collections;

public class RotateSomething : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 0, 10.0f);
	}
}
