using UnityEngine;
using System.Collections;

public class ZipLine : MonoBehaviour {


    public Vector3 Destination;
    public float speed = 3;
    public GameObject player;
    public GameObject L_Hand;
    public GameObject R_Hand;
    public bool active;

    private void OnTriggerEnter(Collider other)
    {
        if (L_Hand.transform.position.y > 1 && R_Hand.transform.position.y > 1)
        {
            Debug.LogError("boop");
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
                Vector3 temp;
                temp = Destination;
                temp *= speed;
                gameObject.transform.position = transform.position + (temp * Time.deltaTime);
                player.transform.position = transform.position + (temp * Time.deltaTime);
            }
    }
}
