using UnityEngine;
using System.Collections;

public class ZipLine : MonoBehaviour {


    public Vector3 Destination;
    public float speed = 3;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            Debug.LogError("boop");
            Zip();
        }
    }

    void Zip()
    {
        
    }


    void Start()
    {
        
    }

    //void OnCollisionStay(Collision collisionInfo)
    //{
    //    if (collisionInfo.gameObject == player && OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.A))
    //    {
    //        Active = true;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        while (transform.position.y >= Destination.y)
        {
            Vector3 temp;
            temp = Destination;
            temp *= speed;
            gameObject.transform.position = transform.position + (temp * Time.deltaTime);
        }
    }

}
