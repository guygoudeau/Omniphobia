using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public bool open = false;
    public float doorOpenAngle = -90f;
    public float doorCloseAngle = 0f;
    public float smooth = 1f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
    public void ChangeDoorState()
    {
        open = !open;
    }

	// Update is called once per frame
	void Update ()
    {
        if(open)
        {
            Quaternion targetRot = Quaternion.Euler(0,doorOpenAngle,0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime);
        }
        else
        {
            Quaternion targetRot2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot2, Time.deltaTime);
        }
	}
}
