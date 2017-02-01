using UnityEngine;
using System.Collections;

public class stuff : MonoBehaviour {

    [SerializeField]
    GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown("x"))
        {
            SceneChanger.ChangeScene(Player, 2);
        }
	}
}
