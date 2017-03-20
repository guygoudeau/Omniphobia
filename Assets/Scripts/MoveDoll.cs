using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveDoll : MonoBehaviour {

    private List<DollPosition> _possiblePositions;
    private DollPosition _currentPos;

    private bool _playerLooked = false;
    private bool _timerRun = false;

    private float _posAmount = 0;
    private float _timer = 0;

	// Use this for initialization
	void Start () {
        _timer = 0;
        _timerRun = false;
        _possiblePositions = new List<DollPosition>();

        foreach (DollPosition dp in FindObjectsOfType<DollPosition>())
        {
            if (dp.transform.position == transform.position)
            {
                _currentPos = dp;
                _currentPos.IsOccupied = true;
                _possiblePositions.Add(dp);
                _posAmount++;
            }
            else if (Mathf.Abs(dp.transform.position.magnitude - transform.position.magnitude) <= 1)
            {
                _possiblePositions.Add(dp);
                _posAmount++;
            }

        }
    }
	
	// Update is called once per frame
	void Update () {

        if(_timerRun)
        {
            _timer += Time.deltaTime;
        }

        if(this.gameObject.GetComponentInChildren<MeshRenderer>().isVisible)
        {
            _playerLooked = true;
            _timerRun = true;
            _timer = 0;
        }
        else if(_playerLooked && _timer >= 10)
        {
            int NewPos = (int)Random.Range(0, _posAmount);
            while(_possiblePositions[NewPos] == _currentPos)
                NewPos = (int)Random.Range(0, _posAmount);
            _currentPos.IsOccupied = false;
            _currentPos = _possiblePositions[NewPos];
            _currentPos.IsOccupied = true;
            transform.position = _currentPos.transform.position;
            _playerLooked = false;
            _timer = 0;
            _timerRun = false;
        }
	}
}
