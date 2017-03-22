using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveDoll : MonoBehaviour {
    
    //List to store the different positions the Doll can move to.
    private List<DollPosition> _possiblePositions;
    //The current position the Doll is occupying.
    private DollPosition _currentPos;

    private GameObject _player;

    //A boolean to know if the Doll entered the camera view or not.
    private bool _playerLooked = false;
    //A boolean to know if the time should be incremented.
    public bool _timerRun = false;

    //The number of positions that are available to the Doll for occupation.
    private float _posAmount = 0;
    //The number of seconds passed since the Doll entered the camera view.
    private float _time = 0;

    private int _pos = 0;

	// Use this for initialization
	void Start () {
        _time = 0;
        _timerRun = false;
        _possiblePositions = new List<DollPosition>();
        _player = GameObject.Find("OVRPlayerController");

        //A foreach loop to find all the DollPositions and determines which ones are available to occupy.
        foreach (DollPosition dp in GameObject.Find("Positions").GetComponentsInChildren<DollPosition>())
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
            Debug.Log(dp.name);
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Increments the time by deltaTime if the timer is running.
        if(_timerRun)
        {
            _time += Time.deltaTime;
        }

        //Checks to see if the Doll entered the Camera view.
        if(this.gameObject.GetComponentInChildren<MeshRenderer>().isVisible)
        {
            _playerLooked = true;
        }
        else if (((int)Vector3.Distance(transform.position, _player.transform.position) <= 3) && _playerLooked)
        {
            _timerRun = true;
            _time = 0;
        }
        //Checks to see if more than ten seconds have passed since the Doll has left the Camera view.
        else if(_playerLooked && _time >= 2)
        {
            _pos++;

            if (_pos >= _possiblePositions.Count)
                _pos = 0;

            _currentPos.IsOccupied = false;
            _currentPos = _possiblePositions[_pos];
            _currentPos.IsOccupied = true;

            transform.position = _currentPos.transform.position;
            transform.rotation = _currentPos.transform.rotation;

            _playerLooked = false;
            _time = 0;
            _timerRun = false;
        }
	}
}
