using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class BossFight : MonoBehaviour {
    public bool isEnabled;

    // Use this for initialization
    void Start()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            isEnabled = true;
            foreach (Transform Light in gameObject.transform)
            {
                Light.gameObject.SetActive(true);
            }
            Events.FireLit.Invoke();
        }       
    }
}
