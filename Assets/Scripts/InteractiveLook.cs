using UnityEngine;
using System.Collections;

public class InteractiveLook : MonoBehaviour {

    public GameObject _player;    
    public bool Sitting = false;
    private IEnumerator _fadeIn;

    void Start () {

        _player = GameObject.FindObjectOfType<OVRPlayerController>().gameObject;

        if (_player == null)
        {
            Debug.LogError("OVRPlayerController not found.");
            this.enabled = false;
        }
        else
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);
    }
	
	void Update () {
        Vector3 fwd = new Vector3(0, 0, 0);
        if (_player != null)
        {
            fwd = _player.transform.TransformDirection(Vector3.forward);
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);
        }

        RaycastHit hit;
        if(Physics.Raycast(this.gameObject.transform.position,fwd, out hit,1f))
        {
            Debug.DrawLine(this.gameObject.transform.position, hit.point);
            if (hit.collider.GetComponent<OpenDoor>() != null)
            {
                if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.T))
                {
                    hit.collider.transform.GetComponent<OpenDoor>().ChangeDoorState();
                    //StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(_sceneNum));
                }
            }           
            ///Backlog till further notice
            ///Dylan Guidry
            //if(hit.collider.name.Contains("Chair"))
            //{
            //    if (!Sitting)
            //    {
            //        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("r"))
            //        {
            //            _player.transform.position = new Vector3(hit.collider.transform.position.x, _player.transform.position.y, hit.collider.transform.position.z);
            //            _player.transform.rotation = hit.collider.transform.rotation;
            //            Sitting = true;
            //        }
            //    }
            //    else if (Sitting)
            //    {
            //        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("r"))
            //        {
            //            _player.transform.Translate(transform.forward);
            //            Sitting = false;
            //        }
            //    }
            //}
        }
    }
}
