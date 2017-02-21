using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphaFade : MonoBehaviour {

    private Image _brightLight;

	// Use this for initialization
	void Start () {
        _brightLight = transform.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Fadein(int sceneNum)
    {
        for(float i = 0f; i < 255; i += Time.deltaTime)
        {
            _brightLight.color = new Color(255,255,255,i);
        }
        SceneChanger.ChangeScene(FindObjectOfType<CharacterController>().transform.gameObject, sceneNum);
        yield return null;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
