using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public enum KeyColors
    {
        NONE, RED, BLUE, GREEN
    }

    [SerializeField]
    private KeyColors keyColor;
    [HideInInspector]
    public Color KeyColor;

	// Use this for initialization
	void Start ()
    {
	    switch(keyColor)
        {
            case KeyColors.RED:
                KeyColor = Color.red;
                break;
            case KeyColors.GREEN:
                KeyColor = Color.green;
                break;
            case KeyColors.BLUE:
                KeyColor = Color.blue;
                break;
            default:
                KeyColor = Color.black;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= 0.9f)
            transform.position = new Vector3(-7.315f, 2.2f, 23.43f);
	}
}
