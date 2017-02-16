using UnityEngine;
using System.Collections;

public class Sway : MonoBehaviour {

    public float speed = 1.0f; // speed of the roatation.
    private Quaternion startPos; //used to reset current position every frame.
    public float Delta; //magnitude of the rotation.

    // Use this for initialization
    void Start () {
        startPos = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        Quaternion Q = startPos;
        //Vector3 V = transform.position;
        Q.w += Delta * Mathf.Sin(Time.fixedTime * speed);
        Q.x += Delta  * Mathf.Sin(Time.fixedTime * speed);
        Q.z += Delta  * Mathf.Cos(Time.fixedTime * speed);
        Q.y += Delta * Mathf.Sin(Time.fixedTime * speed);
        //V.y += (Delta * Mathf.Sin(Time.fixedTime * speed));
        //transform.position = V;
        transform.rotation = Q;
    }
}
