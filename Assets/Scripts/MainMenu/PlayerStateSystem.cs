using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateSystem : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        Player = FindObjectOfType<OVRPlayerController>().gameObject;
    }

	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Heights" && Player.transform.position.y <= -72.5)
        {
            Events.PlayerDeath.Invoke();
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Events.PlayerDeath.Invoke();
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKeyDown("f"))
        {
            Events.PlayerForceScene.Invoke();
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            Events.RoomCompleted.Invoke();
        }
    }
}
