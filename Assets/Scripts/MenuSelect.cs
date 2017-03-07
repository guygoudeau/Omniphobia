using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            SceneManager.LoadScene("Menu");
        }
    }

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Play"))
        {
            StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(1));
        }
    }

    
}