using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene("Menu");
        }
    }

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Play"))
        {
            SceneManager.LoadScene("Library");
        }
    }

    
}