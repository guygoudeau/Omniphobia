using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FallingFloor : MonoBehaviour {

    public List<GameObject> Tiles;
    public GameObject player;
    public float speed;
    private bool first;
    public GameObject BreakList;

    void Start()
    {
        first = true;
        foreach (Transform child1 in transform)
        {
            if (child1.name == "Break")
            {
                BreakList = child1.gameObject;
            }
        }
        foreach (Transform child2 in BreakList.GetComponentsInChildren<Transform>())
        {
            if (child2.name != "Break")
            {
                Tiles.Add(child2.gameObject);
            }
        }
    }

    void Update()
    {
        if (player.transform.rotation.x < 75 && first)
        {
            StartCoroutine(Fall());
            first = false;
        }
    }

    public IEnumerator Fall()
    {
        foreach (GameObject obj in Tiles)
        {
            obj.AddComponent<Rigidbody>();
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().useGravity = true;
            Destroy(obj.GetComponent<BoxCollider>());
            obj.GetComponent<Rigidbody>().AddTorque(56, 25, 140);
            yield return new WaitForSeconds(speed/10);
        }
    }
}
