///<summary>
/// -Attach to object that will be following the waypoints.
/// -ensure that a Nav Mesh agent to the object and turn off auto breaking.
/// -create a terrain and open the Navigation window, from the windows tab in unity.
/// -click on the terrain while looking in the navigation window and turn on the navigation static box, and set it to walkable.
/// -Attach the GameObject of the terrain that the object will be traversing to the variable labeled.
/// -Create an Empty game object, and call it "Points"
/// -Add empty game objects and position their transform at the waypoints that the object is supposed to walk to.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(NavMeshAgent))]
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
    public GameObject Terrain;
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
        foreach (Transform a in Terrain.transform)
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
                Ptimer = 5;
                Pursuit = true;
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
