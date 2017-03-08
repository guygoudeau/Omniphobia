using UnityEngine;
using System.Collections;

public class InteractiveLook : MonoBehaviour {

    private GameObject _player;
    private Transform _self;
    public bool Sitting = false;
    private IEnumerator _fadeIn;

    // Use this for initialization
    void Start () {
        if (_player == null)
        {
            foreach (GameObject go in FindObjectsOfType<GameObject>())
            {
                if (go.name == "OVRPlayerController")
                {
                    _player = go;
                }
                else if (go.name == "First Person Controller")
                {
                    _player = go;
                }
                else if (go.name == "Interact")
                {
                    _self = go.transform;
                }
            }
        }
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = new Vector3(0, 0, 0);
        if (_player != null)
        {
            fwd = _player.transform.TransformDirection(Vector3.forward);
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);
        }

        RaycastHit hit;
        if(Physics.Raycast(_self.position,fwd, out hit,1f))
        {
            Debug.DrawLine(_self.position, hit.point);
            //Debug.Log(hit.collider.transform.parent.name);
            if (hit.collider.transform.parent != null)
            {
                if (hit.collider.name.Contains("Door"))
                {
                    Debug.Log(hit.collider.transform.parent.name);
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        hit.collider.transform.parent.GetComponent<OpenDoor>().ChangeDoorState();
                        int _sceneNum = 0;
                        int enumeration = 0;
                        while (_sceneNum == 0)
                        {
                            if (hit.collider.name.Contains(enumeration.ToString()))
                            {
                                _sceneNum = enumeration;
                                break;
                            }
                            else
                                enumeration++;
                        }
                        StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(_sceneNum));
                    }
                }
            }
            if(hit.collider.name.Contains("Chair"))
            {
                if (!Sitting)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        _player.transform.position = new Vector3(hit.collider.transform.position.x, _player.transform.position.y, hit.collider.transform.position.z);
                        _player.transform.rotation = hit.collider.transform.rotation;
                        Sitting = true;
                    }
                }
                else if (Sitting)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        _player.transform.Translate(transform.forward);
                        Sitting = false;
                    }
                }
            }
        }
    }
}
