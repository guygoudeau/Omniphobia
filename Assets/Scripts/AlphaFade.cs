using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlphaFade : MonoBehaviour {

    private Image _brightLight;
    private bool _fadingOut = false;
    public int Alpha = 0;

	// Use this for initialization
	void Start () {
        _brightLight = transform.gameObject.GetComponent<Image>();
        foreach(Camera ca in FindObjectsOfType<Camera>())
        {
            if(ca.name == "CenterEyeAnchor")
            {
                transform.parent.GetComponent<Canvas>().worldCamera = ca;
                transform.parent.GetComponent<Canvas>().planeDistance = 0.101f;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (_fadingOut)
        {
            StartCoroutine(FadeOut());
            _fadingOut = false;
        }
	
	}

    public IEnumerator FadeIn(int sceneNum)
    {
        for(float i = 0f; i < 256; i++)
        {
            Alpha = (int)i;
            _brightLight.color = new Color(255,255,255,i/255);
            if(i >= 255)
            {
                SceneManager.LoadScene(sceneNum);
                _fadingOut = true;
            }
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        for (float i = 255f; i >= 0; i--)
        {
            _brightLight.color = new Color(255, 255, 255, i/255);
            yield return null;
        }
    }

    void Awake()
    {
        if (FindObjectOfType(typeof(AlphaFade)) == this)
            return;
        DontDestroyOnLoad(transform.parent);
    }
}
