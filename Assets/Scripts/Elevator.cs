using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public Vector3 Destination;
    public float speed;
    public GameObject door1;
    public GameObject door2;
    public bool Close;

    void Start()
    {
        if (Close)
        {
            StartCoroutine(OpenDoor(1));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Close)
        {
            StartCoroutine(OpenDoor(0));
        }
        StartCoroutine(Lerp(other.gameObject));
    }

    private IEnumerator Lerp(GameObject player)
    {
        if (Destination.y / Mathf.Abs(Destination.y) == 1)
        {
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
        StartCoroutine(OpenDoor(1));
    }

    private IEnumerator OpenDoor(int Direction)
    {
        Vector3 newDest = new Vector3(door1.transform.localPosition.x - 0.00345033f, door1.transform.localPosition.y, door1.transform.localPosition.z) * Direction;
        while (door1.transform.localPosition != newDest)
        {
            door1.transform.localPosition += ((newDest - door1.transform.localPosition) * Time.deltaTime);
            door2.transform.localPosition -= ((newDest - door1.transform.localPosition) * Time.deltaTime);
            yield return 0;
        }
    }
}
