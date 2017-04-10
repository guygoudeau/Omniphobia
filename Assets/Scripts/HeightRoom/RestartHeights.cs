using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartHeights : MonoBehaviour {

    public GameObject player;

	void OnTriggerEnter(Collider other)
    {
        if (other = player.GetComponent<CharacterController>())
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
