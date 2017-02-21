using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject player;
    public int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        SceneChanger.ChangeScene(player, sceneNumber);
    }
}
