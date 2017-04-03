///<summary>
///A fairly empty class made to allow the MoveDoll script have an easier time referencing the Doll waypoints
///Needs to be attached to an empty GameObject that is a child of a GameObject called "Positions"
///</summary>
using UnityEngine;
using System.Collections;

public class DollPosition : MonoBehaviour {

    public bool IsOccupied = false;

	// Use this for initialization
	void Start () {
        IsOccupied = false;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
