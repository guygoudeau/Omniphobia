using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public Vector3 Destination;
    public float speed;
    public float doorSpeed;
    public GameObject door1;
    public GameObject door2;
    public bool Open;

    void Start()
    {
        if (Open)
        {
            StartCoroutine(OpenDoor(1));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Open)
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

    private IEnumerator OpenDoor(float Direction)
    {
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>();
        }
        Vector3 newDest = new Vector3(door1.transform.localPosition.x - 0.00345033f, 0, 0) * Direction;
        while (door1.transform.localPosition.x != newDest.x)
        {
            door1.transform.localPosition += new Vector3(newDest.x - door1.transform.localPosition.x, 0, 0) * doorSpeed * Time.deltaTime;
            door2.transform.localPosition -= new Vector3(newDest.x - door1.transform.localPosition.x, 0, 0) * doorSpeed * Time.deltaTime;
            yield return 0;
        }
    }
}
