using UnityEngine;
using System.Collections;

public class ZipLine : MonoBehaviour {


    public Vector3 Destination;
    //private Vector3 startPosition;
    public float speed = 3;
    private GameObject player;
    public GameObject L_Hand;
    public GameObject R_Hand;
    public bool active;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            Zip();
        }
    }

    void Zip()
    {
        active = true;
    }


    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (active)
            {
            //player.GetComponent<CharacterController>()
            transform.position = Vector3.Lerp(transform.position, Destination, speed * Time.deltaTime);
            player.transform.position = Vector3.Lerp(player.transform.position, Destination, speed * Time.deltaTime);
        }
    }
}
