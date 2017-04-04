///<summary>
///Used for elevating the object and player simultainiusly.
///</summary>
using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider))]
public class Elevator : MonoBehaviour {

    // The vector we will be moving towards.
    public Vector3 Destination;
    // The speed we will be going towards the destination.
    public float speed;
    // The speed the door opens at.
    public float doorSpeed;
    // The first door object.
    public GameObject door1;
    // The second door object.
    public GameObject door2;
    // The Player.
    private GameObject rider;
    // Used to determine which elevator it is.
    public bool Open;
    private Coroutine co;

    // Gets called first.
    void Start()
    {
        // Checks what elevator it is and opens the door if it is the second elevator.
        if (Open)
        {
            co = StartCoroutine(OpenDoor(1));
        }
    }

    // Gets called when the player goes in the elevator.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Close the door if its open.
            if (Open)
            {
                StopCoroutine(co);
                co = StartCoroutine(OpenDoor(0));
            }
            rider = other.gameObject;
            // Start moving.
            StartCoroutine(Lerp(rider));
        }
    }

    // Moves the elevator and player in it to the set Destination.
    private IEnumerator Lerp(GameObject player)
    {
        // Choses if we are going up or down.
        if (Destination.y / Mathf.Abs(Destination.y) == 1)
        {
            // Changes player and elevator y position over deltaTime times speed.
            while (transform.position.y <= Destination.y)
            {
                Vector3 temp;
                temp = Destination * Time.deltaTime;
                temp *= speed;
                gameObject.transform.position = transform.position + temp;
                player.transform.position = player.transform.position + temp;
                yield return 0;
            }
        }
        else if (Destination.y / Mathf.Abs(Destination.y) == -1)
        {
            // Changes player and elevator y position over deltaTime times speed.
            while (transform.position.y >= Destination.y)
            {
                Vector3 temp;
                temp = Destination * Time.deltaTime;
                temp *= speed;
                gameObject.transform.position = transform.position + temp;
                player.transform.position = player.transform.position + temp;
                yield return 0;
            }
        }
        if (co != null)
        {
            StopCoroutine(co);
        }
        StartCoroutine(OpenDoor(1));
    }

    // Makes the doors open or close depending on the value passed. 1 = Open, 0 = Close, -1 = Invert
    private IEnumerator OpenDoor(float Direction)
    {
        // This will be the vector we move on. This vector is also multipled by the passed in direction.
        Vector3 newDest = new Vector3(door1.transform.localPosition.x - 0.003450f, 0, 0) * Direction;
        // Coroutine moves doors in to place over deltaTime times the doorSpeed.
        while (door1.transform.localPosition.x != newDest.x)
        {
            Vector3 Delta = new Vector3(newDest.x - door1.transform.localPosition.x, 0, 0) * doorSpeed * Time.deltaTime;
            door1.transform.localPosition += Delta;
            door2.transform.localPosition -= Delta;
            yield return 0;
        }
    }
}

///PLayer reF should not be hard set