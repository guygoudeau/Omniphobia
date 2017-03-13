using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key")
        {
            UnlockElevator();
        }
        
    }
    void UnlockElevator()
    {

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
