using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public Vector3 Destination;
    public float speed;
    public GameObject door1;
    public GameObject door2;

    void OnTriggerEnter(Collider other)
    {
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
        GetComponent<Animator>().enabled = true;
    }
}
