using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FallingFloor : MonoBehaviour {

    public List<GameObject> Tiles;
    public GameObject player;
    public float speed;
    private bool first;

    void Start()
    {
        first = true;
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
            obj.GetComponent<Rigidbody>().rotation = new Quaternion(0, 20, 10, 0);
            yield return new WaitForSeconds(speed / 10);
        }
    }
}
