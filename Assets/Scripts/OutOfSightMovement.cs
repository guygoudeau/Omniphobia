using UnityEngine;
using System.Collections;

public class OutOfSightMovement : MonoBehaviour {

    public bool IsVisible = false;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.GetComponent<MeshRenderer>().isVisible)
        {

        }
	}
}
