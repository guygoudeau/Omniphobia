using UnityEngine;
using System.Collections;

public class Sway : MonoBehaviour {

    public float speed = 1;

    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.rotation.z >= -1)
        {
            transform.Rotate((Mathf.Sin(Time.deltaTime * speed)), 0, 0, 0);
        }
        else 
        {
            transform.Rotate(-(Mathf.Sin(Time.deltaTime * speed)), 0, 0, 0);
        }
    }
}
