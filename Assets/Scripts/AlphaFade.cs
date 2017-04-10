///<summary>
///This script contains two coroutines that fade a white image in and out in front of the camera and transitions the game to the next scene.
///This script must be attached to a GameObject with an Image component that is parented to a Canvas.
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(RectTransform))]
public class AlphaFade : MonoBehaviour
{


    private Image _brightLight;
    private bool _fadingOut = false;
    public int Alpha = 0;

    // Use this for initialization
    void Start()
    {
        _brightLight = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        int Count = 0;

        foreach (AlphaFade af in FindObjectsOfType<AlphaFade>())    //Finds the amount of AlphaFade scripts in the scene.
            Count++;

        if (Count >= 2)
            DestroyObject(transform.parent.gameObject);             //Destroys the parent object if there is already another AlphaFade in existance.

        else
            DontDestroyOnLoad(transform.parent);                    //Persists the AlphaFade if it is the only one at the start of the scene.

    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.parent != GameObject.Find("LeftEyeAnchor").transform)
        //{
        //    transform.SetParent(GameObject.Find("LeftEyeAnchor").transform);
        //    GetComponent<RectTransform>().localPosition = new Vector3(0.009999275f, 0, 0.11f);
        //}
        if (_fadingOut)
        {
            StartCoroutine(FadeOut());
            _fadingOut = false;
        }
    }

    //Coroutine that fades the Image in by increasing the Alpha and when the Image is at full Alpha a new scene is loaded using the passed in integer.
    //-----------------------------------------------------
    // SOME OTHER SCRPIT NEEDS TO CALL THIS FUNCTION!
    //-----------------------------------------------------
    public IEnumerator FadeIn(int sceneNum)
    {
        //For loop that increases the alpha of the image
        for (float i = 0f; i < 256; i++)
        {
            Alpha = (int)i;
            _brightLight.color = new Color(255, 255, 255, i / 255);
            if (i >= 255)
            {
                //Loads the next scene, sets the bool to start the FadeOut coroutine to true, and stops the FadeIn coroutine
                SceneManager.LoadScene(sceneNum);
                _fadingOut = true;
            }
            yield return null;
        }
    }

    //Coroutine that fades the Image out by decreasing the Alpha until it is at zero Alpha.
    public IEnumerator FadeOut()
    {
        //For loop that decreases the alpha of the image
        for (float i = 255f; i >= 0; i--)
        {
            _brightLight.color = new Color(255, 255, 255, i / 255);
            yield return null;
        }
    }
}
