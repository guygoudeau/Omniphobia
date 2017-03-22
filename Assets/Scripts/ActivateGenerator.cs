using UnityEngine;
using System.Collections;

public class ActivateGenerator : MonoBehaviour
{
    public float power = 0;
    public bool activated = false;
    Transform Light;

    void Start()
    {
        Light = gameObject.transform.GetChild(0);
    }

	void Update()
    {
	    if (power >= 100)
        {
            power = 100;
            activated = true;
            Light.GetComponent<Renderer>().material.color = Color.green;
        }
	}
}
