using UnityEngine;
using System.Collections;

public class InteractiveLook : MonoBehaviour {

    private GameObject _player;
    private Transform _self;
    public bool Sitting = false;

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
        Vector3 fwd = _player.transform.TransformDirection(Vector3.forward);
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + .05f, _player.transform.position.z);

        RaycastHit hit;
        if(Physics.Raycast(_self.position,fwd, out hit,1f))
        {
            Debug.DrawLine(_self.position, hit.point);
            if(hit.collider.name.Contains("Door") )
            {
                if(Input.GetKeyDown("e"))
                {
                    int _sceneNum = 0;
                    int enumeration = 0;
                    while(_sceneNum == 0)
                    {
                        if (hit.collider.name.Contains(enumeration.ToString()))
                        {
                            _sceneNum = enumeration;
                            break;
                        }
                        else
                            enumeration++;
                    }
                    SceneChanger.ChangeScene(_player, _sceneNum);
                    FindObjectOfType<stuff>().CurrentScene++;
                }
            }
            if(hit.collider.name.Contains("Chair"))
            {
                if (!Sitting)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        _player.transform.position = new Vector3(hit.collider.transform.position.x, _player.transform.position.y, hit.collider.transform.position.z);
                        _player.transform.rotation = hit.collider.transform.rotation;
                        Sitting = true;
                    }
                }
                else if (Sitting)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        _player.transform.Translate(transform.forward);
                        Sitting = false;
                    }
                }
            }
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
