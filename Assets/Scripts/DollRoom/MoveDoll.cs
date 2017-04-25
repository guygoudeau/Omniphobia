///<summary>
///This script moves the GameObject between different positions in an order when the player looks at the GameObject and has come within a certain distance of the GameObject.
///This script also causes the GameObject to become invisible when moved and fade in quickly every time it changes position.
///This script also ends the changing of positions once the GameObject reaches the last position. It then turns on the PopDoll script that should exist in a child
///     of the GameObject. It updates the rotation of one of the GameObject's children called "Body" and updates the Force in the PopDoll script according to the new forward.
///This script requires a GameObject called "Positions" with children that have a DollPosition script attached to them to exist in the scene.
///This script requires a player GameObject called "OVRPlayerController" in the scene, a Material in the Resources folder called "DollTempMat" (subject to change),
///     and requires three children parented to the GameObject called "Target" and "Body" and the third needs to have the DollHead script attached to it.
///"Target" requires a BoxCollider and a PopDoll component.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveDoll : MonoBehaviour {

    //List to store the different positions the Doll can move to.
    private List<DollPosition> _possiblePositions;
    //The current position the Doll is occupying.
    private DollPosition _currentPos;

    private GameObject _player;

    private Transform _targetTransform;

    private Transform _dollBody;

    //A boolean to know if the Doll entered the camera view or not.
    private bool _playerLooked = false;
    //A boolean to know if the time should be incremented.
    public bool _timerRun = false;
    //A boolean to know if the movement between waypoints is over or not
    private bool _movementOver = false;

    //The number of positions that are available to the Doll for occupation.
    private float _posAmount = 0;
    //The number of seconds passed since the Doll entered the camera view.
    private float _time = 0;

    private int _pos = 0;

    // Use this for initialization
    void Start() {
        _time = 0;
        _timerRun = false;
        _possiblePositions = new List<DollPosition>();
        _player = GameObject.Find("OVRPlayerController");
        transform.gameObject.GetComponentInChildren<PopDoll>().enabled = false;

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material = Resources.Load("DollTempMat") as Material;
        }

        //A foreach loop to find all the DollPositions and determines which ones are available to occupy.
        foreach (DollPosition dp in GameObject.FindGameObjectWithTag("Positions").GetComponentsInChildren<DollPosition>())
        {
            if (dp.transform.position == transform.position)
            {
                _currentPos = dp;
                _currentPos.IsOccupied = true;
                _possiblePositions.Add(dp);
                _posAmount++;
            }
            else
            {
                _possiblePositions.Add(dp);
                _posAmount++;
            }
        }

        //Finds the Target child in the gameObject
        foreach (Transform tf in transform.GetComponentInChildren<Transform>())
        {
            if (tf.name == "Target")
            {
                _targetTransform = tf;
            }
            else if (tf.name == "Body")
            {
                _dollBody = tf;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        //Increments the time by deltaTime if the timer is running.
        if (_timerRun)
        {
            _time += Time.deltaTime;
        }

        //Checks to see if the Player is within 4.5 unity units of distance from the Doll and if the movement is still happening
        if (((int)Vector3.Distance(transform.position, _player.transform.position) <= 4.5f) && !_movementOver)
        {
            _timerRun = true;
            _time = 0;
        }
        //Checks to see if the timer is running and if the time is 1 or more seconds
        //If true the Doll is moved to the next waypoint
        else if (_timerRun && _time >= 1)
        {
            _pos++;

            if (_pos >= _possiblePositions.Count)
                _pos = 0;

            _currentPos.IsOccupied = false;
            _currentPos = _possiblePositions[_pos];
            _currentPos.IsOccupied = true;

            //Code that needs to be run in order to properly change the render mode of a material through code
            //This changes it to Fade mode
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.SetFloat("_Mode", 2.0f);
                r.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                r.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                r.material.SetInt("_ZWrite", 0);
                r.material.DisableKeyword("_ALPHATEST_ON");
                r.material.EnableKeyword("_ALPHABLEND_ON");
                r.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                r.material.renderQueue = 3000;
                Color tempColor = r.material.color;
                tempColor.a = 0;
                r.material.color = tempColor;
            }

            transform.position = _currentPos.transform.position;
            transform.rotation = _currentPos.transform.rotation;
            StartCoroutine(FadeIn());

            _playerLooked = false;
            _time = 0;
            _timerRun = false;

            //If statement that changes the behavior of the Doll when it reaches the last waypoint
            if (_pos == 9)
            {
                transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                transform.gameObject.GetComponentInChildren<PopDoll>().enabled = true;
                transform.gameObject.GetComponentInChildren<PopDoll>().force = (_dollBody.forward * 5) + (_dollBody.up * 4f);
                _movementOver = true;
            }
        }

        //Updates the Doll's body's rotation and the force that will be used to pop the Doll
        else if (_pos == 9)
        {
            _targetTransform.LookAt(_player.transform);
            Quaternion TargetRot = _targetTransform.localRotation;
            _dollBody.localRotation = new Quaternion(0, TargetRot.y, 0, TargetRot.w);

            transform.gameObject.GetComponentInChildren<PopDoll>().force = (_dollBody.forward * 5) + (_dollBody.up * 4f);
        }
    }

    public IEnumerator FadeIn()
    {
        //For loop that increases the alpha of the material colors
        for (float i = 0f; i < 256; i += 0.05f)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                Color tempColor = r.material.color;
                tempColor.a = i;
                r.material.color = tempColor;

                //Code that needs to be run in order to properly change the render mode of a material through code
                //This changes it to Standard mode
                if (i >= 255f)
                {
                    r.material.SetFloat("_Mode", 0.0f);
                    r.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    r.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                    r.material.SetInt("_ZWrite", 1);
                    r.material.DisableKeyword("_ALPHATEST_ON");
                    r.material.DisableKeyword("_ALPHABLEND_ON");
                    r.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    r.material.renderQueue = -1;
                }
            }
            yield return null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4.5f);
    }
}
