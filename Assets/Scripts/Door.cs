using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public GameObject player;
    public int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
