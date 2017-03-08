using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateSystem : MonoBehaviour
{
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Heights" && transform.position.y <= -200)
        {
            Events.PlayerDeath.Invoke();
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Events.PlayerReloadScene.Invoke();
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Events.PlayerForceScene.Invoke();
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            Events.PlayerWin.Invoke();
        }
    }
}
