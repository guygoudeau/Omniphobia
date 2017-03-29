using UnityEngine;
using System.Collections;

public class ActivateGenerator : MonoBehaviour
{
    public float power = 0;
    public bool activated = false;
    GameObject player;
    Transform powerLight;
    Transform self; 

    void Awake()
    {
        self = this.transform;
    }

    void Start()
    {
        powerLight = gameObject.transform.GetChild(0);
        player = GameObject.FindWithTag("Player");
    }
    
	void Update()
    {
        Vector3 fwd = player.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(self.position, fwd, out hit, 2f))
        {
            if (hit.collider.tag == "Generator")
            {
                if (Input.GetKey("f"))
                {
                    power += 1;
                }
            }
        }

        if (power >= 100)
        {
            power = 100;
            activated = true;
            powerLight.GetComponent<Renderer>().material.color = Color.green;
        }
	}
}