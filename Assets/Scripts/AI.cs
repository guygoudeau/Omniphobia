using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {

    // Player player;
    //Vector3 position;
    public GameObject Target;
    public uint offSetDis;
    public float speed;
    public List<Transform> Waypoints = new List<Transform>();
    public Transform a, b, c, d, e, f;
    public Transform Destination;
    GameObject Points;
    public GameObject Maze;
    int index;
    NavMeshAgent Spider;

    private void Start()
    {
        //Waypoints = new SortedList();
        Waypoints = new List<Transform>();
        foreach (Transform a in Maze.transform)
        {
            if (a.name == "Points")
            {
                Points = a.gameObject;
            }
        }
        foreach (Transform b in Points.GetComponentsInChildren<Transform>())
        {
             Waypoints.Add(b.transform);
        }

        index = 0;
        Spider = GetComponent<NavMeshAgent>();
        Spider.speed = 6;
    }
    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        
        Spider.destination = WayPoint(transform.position);
        // Changes position to the return value of seek.
        //transform.position = Seek(Target.transform.position, transform.position);
    }

    // Does cool math that moves the enemy toward the target object with an offSet.
    bool RoundPos(Vector3 CurrentPos, Vector3 Target)
    {
        if(Vector3.Distance(CurrentPos, Target) <= offSetDis)
        {
            return true;
        }
        return false;
  
    }
    Vector3 WayPoint(Vector3 Pos)
    {
        Destination = Waypoints[index];
        //changes the target when close enough
        if (RoundPos(transform.position, Destination.position) == true)
        {
            index++;
            if (index == Waypoints.Count - 1)
            {
                index = 0;
            }
        }
        return Destination.position;
    }
}
