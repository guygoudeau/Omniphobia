using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    bool win;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRPlayerController")
        {
            other.GetComponent<GameManager>().Checkpoint = CPoint;
        }
    }
    public Vector3 CPoint;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
