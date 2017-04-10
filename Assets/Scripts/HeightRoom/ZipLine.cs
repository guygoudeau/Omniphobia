///<summary>
///Used for moving the player down a zipline.
///</summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ZipLine : MonoBehaviour {

    public Vector3 Destination;
    public float speed = 3;
    private GameObject player;
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
        // When active, moves the player to the destination.
            if (active)
            {
            transform.position = Vector3.Lerp(transform.position, Destination, speed * Time.deltaTime);
            player.transform.position = Vector3.Lerp(player.transform.position, Destination, speed * Time.deltaTime);
        }
    }
}
