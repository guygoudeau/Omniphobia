using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class BossFight : MonoBehaviour {


    GameObject Player;
    private bool isEnabled = true;

    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<CharacterController>().gameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Fire")
            return;

        isEnabled = true;
        foreach (Transform Light in gameObject.transform)
        {
            Light.gameObject.SetActive(true);
        }

        var braziers = FindObjectsOfType<BossFight>();
        if (braziers.All(brazier => brazier.isEnabled))
            Events.RoomCompleted.Invoke();


    }
    // Update is called once per frame
    void Update()
    {

    }
}
