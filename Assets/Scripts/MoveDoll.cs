using UnityEngine;
using System.Collections;

public class MoveDoll : MonoBehaviour {

    private bool _playerLooked = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.GetComponentInChildren<MeshRenderer>().isVisible)
        {
            _playerLooked = true;
        }
        else if(_playerLooked)
        {
            float NewX = Random.Range(-2.5f, 2.5f);
            float NewZ = Random.Range(-2.5f, 2.5f);
            transform.position = new Vector3(transform.position.x + NewX, transform.position.y, transform.position.z + NewZ);
            _playerLooked = false;
        }
	}
}
