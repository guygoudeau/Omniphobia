using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour {


    public GameObject Parent;
    public GameObject Player;

    // Use this for initialization
    void Start () {

	}
    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.GetComponent<CharacterController>())
        {
            Parent.GetComponent<AI>().Pursuit = true;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
    
}
