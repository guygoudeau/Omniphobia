using UnityEngine;
using System.Collections;

public class ZipLine : MonoBehaviour {


    public Vector3 Destination;
    private Vector3 startPosition;
    public float speed = 3;
    public GameObject player;
    public GameObject L_Hand;
    public GameObject R_Hand;
    public bool active;

    private void OnTriggerEnter(Collider other)
    {
        //if (L_Hand.transform.position.y > 1 && R_Hand.transform.position.y > 1)
        //{
            Debug.LogError("boop");
        startPosition = player.transform.position;
            Zip();
        //}
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
            transform.position = Vector3.Lerp(startPosition, Destination, speed * Time.deltaTime);
            player.transform.position = Vector3.Lerp(startPosition, Destination, speed * Time.deltaTime);
        }
    }
}
