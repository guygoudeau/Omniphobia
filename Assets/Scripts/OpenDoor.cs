using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class OpenDoor : MonoBehaviour {

    public bool open = false;
    public float doorOpenAngle;
    public float doorCloseAngle;
    public float smooth = 1f;
    public bool OpensAway;

	// Use this for initialization
	void Start ()
    {
        this.doorCloseAngle = this.gameObject.transform.eulerAngles.y;

        if(OpensAway)
            this.doorOpenAngle = this.doorCloseAngle - 90;
        else
            this.doorOpenAngle = this.doorCloseAngle + 90;
    }
	
    public void ChangeDoorState()
    {
        open = !open;
        Events.RoomHeightSelected.Invoke();
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
