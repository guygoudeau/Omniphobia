using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphaFade : MonoBehaviour {

    private Image _brightLight;
    private IEnumerator _fO;
    private bool _fadingOut = false;
    public int Alpha = 0;

	// Use this for initialization
	void Start () {
        _brightLight = transform.gameObject.GetComponent<Image>();
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
            //Alpha = (int)i;
            //Debug.Log(_brightLight.color.a);
            if(i >= 255)
            {
                //_fadingOut = true;
                SceneChanger.ChangeScene(FindObjectOfType<CharacterController>().transform.gameObject, sceneNum);
                _fadingOut = true;
            }
            yield return null;
        }
        //if (_brightLight.color.a >= 255)
        //{
        //    _fadingOut = true;
        //    SceneChanger.ChangeScene(FindObjectOfType<CharacterController>().transform.gameObject, sceneNum);
        //}
        //SceneChanger.ChangeScene(FindObjectOfType<CharacterController>().transform.gameObject, sceneNum);
        //_fO = this.FadeOut();
        //StartCoroutine(_fO);
        //yield return null;
    }

    public IEnumerator FadeOut()
    {
        for (float i = 255f; i >= 0; i--)
        {
            _brightLight.color = new Color(255, 255, 255, i/255);
            yield return null;
        }
        //yield return null;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.parent);
    }
}
