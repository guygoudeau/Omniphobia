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
        if (player.transform.rotation.x < -75 && first)
        {
            StartCoroutine(Fall());
            first = false;
        }
    }

    public IEnumerator Fall()
    {
        //    foreach 
        yield return new WaitForSeconds(speed / 10);
    }
}
