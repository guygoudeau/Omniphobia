using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public GameObject player;
    public Vector3 newPosition;
    public int SceneNumber;

	void OnTriggerEnter(Collider obj)
    {
        player.transform.position = newPosition;
        SceneManager.LoadScene(SceneNumber);
    }
}
