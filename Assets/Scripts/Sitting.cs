using UnityEngine;
using System.Collections;

public class Sitting : MonoBehaviour {

    private Vector3 _parentPos;
    private GameObject _interact;

    // Use this for initialization
    void Start()
    {
        _parentPos = this.transform.parent.transform.position;
        foreach(GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.name == "Interact")
                _interact = go;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay(Collider other)
    {
        if (_interact.GetComponent<InteractiveLook>().Sitting)
        {
            if (other.name == "First Person Controller")
            {
                other.transform.position = new Vector3(_parentPos.x, _parentPos.y + 1.06f, _parentPos.z);
            }
        }
    }

}
