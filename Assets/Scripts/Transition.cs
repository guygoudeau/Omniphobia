using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

    public GameObject player;
    public Vector3 newPosition;
    public int SceneNumber;

	void OnTriggerEnter(Collider obj)
    {
        player.transform.position = newPosition;
        SceneChanger.ChangeScene(player, SceneNumber);
    }
}
