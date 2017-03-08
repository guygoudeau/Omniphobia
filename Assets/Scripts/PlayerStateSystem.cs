using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            Events.PlayerForceScene.Invoke();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            Events.PlayerWin.Invoke();
        }
    }
}
