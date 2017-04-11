using UnityEngine;
using System.Collections;

public class DevSpiderSkip : MonoBehaviour {


    GameObject Player;
    public Transform Cheat;
    public Transform Begin;
    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<CharacterController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Player.transform.position = Cheat.position;
            
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Player.transform.position = Begin.position;
        }

    }
}
