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
    private Vector3 StartPosition;
	// Use this for initialization
	void Start ()
    {
        StartPosition = this.transform.position;
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

    private void Update()
    {
        if (this.transform.position.y <= 0.2F)
            this.transform.position = StartPosition;

    }
}
