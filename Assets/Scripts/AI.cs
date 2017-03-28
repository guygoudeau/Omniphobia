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
    public bool Pursuit = false;
    float Ptimer = 5;
    float Stimer = 2;
    public bool Stop;

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
        if (Stop == true)
        {
            Stimer -= Time.deltaTime;
            if (Stimer <= 0)
            {
                Stimer = 2;
                Stop = false;
            }
        }

        Spider.destination = WayPoint(transform.position);
        // Changes position to the return value of seek.

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
        if (Pursuit == true)
        {
            Ptimer -= Time.deltaTime;
            if (Ptimer <= 0)
            {
                Ptimer = 5;
                Pursuit = false;
            }
            if (Vector3.Distance(transform.position,Target.transform.position) <= 2.5f)
            {
                Stop = true;
                return transform.position;
            }
            else
            return Target.transform.position;
        }
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
