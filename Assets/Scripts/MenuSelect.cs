using UnityEngine;

public class MenuSelect : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Play"))
        {
            StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(1));
        }
    }
}