using UnityEngine;
using System.Collections;

public class ZipLine : MonoBehaviour {

    private bool Active;
    public GameObject player;

    void Start()
    {
        Active = false;
    }

    //void OnCollisionStay(Collision collisionInfo)
    //{
    //    if (collisionInfo.gameObject == player && OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.A))
    //    {
    //        Active = true;
    //    }
    //}

    // Update is called once per frame
    void Update () {
        Debug.Log(Active);
	}
}
