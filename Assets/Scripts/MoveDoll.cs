using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveDoll : MonoBehaviour {
    
    //List to store the different positions the Doll can move to.
    private List<DollPosition> _possiblePositions;
    //The current position the Doll is occupying.
    private DollPosition _currentPos;

    //A boolean to know if the Doll entered the camera view or not.
    private bool _playerLooked = false;
    //A boolean to know if the time should be incremented.
    private bool _timerRun = false;

    //The number of positions that are available to the Doll for occupation.
    private float _posAmount = 0;
    //The number of seconds passed since the Doll entered the camera view.
    private float _time = 0;

	// Use this for initialization
	void Start () {
        _time = 0;
        _timerRun = false;
        _possiblePositions = new List<DollPosition>();

        //A foreach loop to find all the DollPositions and determines which ones are available to occupy.
        foreach (DollPosition dp in FindObjectsOfType<DollPosition>())
        {
            if (dp.transform.position == transform.position)
            {
                _currentPos = dp;
                _currentPos.IsOccupied = true;
                _possiblePositions.Add(dp);
                _posAmount++;
            }
            //Checks to see if the Unity unit distance between the Doll and the DollPosition is less than or equal to 1 Unity unit.
            else if (Mathf.Abs(dp.transform.position.magnitude - transform.position.magnitude) <= 1)
            {
                _possiblePositions.Add(dp);
                _posAmount++;
            }

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
            _timerRun = true;
            _time = 0;
        }
        //Checks to see if more than ten seconds have passed since the Doll has left the Camera view.
        else if(_playerLooked && _time >= 10)
        {
            int NewPos = (int)Random.Range(0, _posAmount);
            //A while loop that makes sure that the position the Doll is moved to is not already the current position.
            while(_possiblePositions[NewPos] == _currentPos)
                NewPos = (int)Random.Range(0, _posAmount);
            _currentPos.IsOccupied = false;
            _currentPos = _possiblePositions[NewPos];
            _currentPos.IsOccupied = true;
            transform.position = _currentPos.transform.position;
            _playerLooked = false;
            _time = 0;
            _timerRun = false;
        }
	}
}
