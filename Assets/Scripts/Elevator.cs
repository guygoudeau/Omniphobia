using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public Vector3 Destination;
    public float speed;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Lerp());
    }

    private IEnumerator Lerp()
    {
        while (gameObject.transform.position != Destination)
        {
            Vector3 temp;
            temp = Destination * Time.deltaTime;
            temp *= speed;
            gameObject.transform.position = transform.position + temp;
            yield return 0;
        }
    }
}
