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
    public List<Transform> Waypoints = new List<Transform>();
    public Transform Destination;
    public Transform LastPoint;
    public Transform ClosestPoint;
    public Vector3 VLastPos = Vector3.zero;
    GameObject Points;
    public GameObject Terrain;
    int index;
    NavMeshAgent Spider;
    public bool Pursuit = false;
    float Ptimer = 10;
    float Stimer = 5;
    public bool Stop;
    public float Velocity = 0;
    public Animator m_anim;
    public float ChaseTimer = 0.0f;
    public bool TimerPursuit = false;
    private bool FirstAttack = true;
    public string pointsTag;

    private void Start()
    {
        //Waypoints = new SortedList();
        Waypoints = new List<Transform>();
        foreach (GameObject a in GameObject.FindGameObjectsWithTag(pointsTag))
        {
            Waypoints.Add(a.transform);
        }

        index = 0;
        Spider = GetComponent<NavMeshAgent>();

        Target = FindObjectOfType<PlayerStateSystem>().gameObject;
    }
    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        //ChaseTimer = Time.realtimeSinceStartup;
        if (Stop == true)
        {
            if (FirstAttack == true)
            {
                m_anim.SetTrigger("Lunge");
                FirstAttack = false;
            }
            Velocity = (transform.position - VLastPos).magnitude * 5;
            m_anim.SetFloat("Speed", Velocity);
            VLastPos = transform.position;
            LastPoint = Destination;
            Stimer -= Time.deltaTime;
            if (Stimer <= 0)
            {
                FirstAttack = true;
                Stimer = 3;
                Stop = false;
                Ptimer = 10;
                Pursuit = true;
            }
        }
        //if (ChaseTimer >= 100)
        //{
        //    Pursuit = true;
        //}
        if (Stop != true)
        { 
            Spider.destination = WayPoint(transform.position);
        }
        else
        {
            Velocity = (transform.position - VLastPos).magnitude * 5;
            m_anim.SetFloat("Speed", Velocity);
            VLastPos = transform.position;
            LastPoint = Destination;
            Spider.destination = gameObject.transform.position;
        }
        // Changes position to the return value of seek.

    }

    // Does cool math that moves the enemy toward the target object with an offSet.
    public bool RoundPos(Vector3 CurrentPos, Vector3 Target)
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
            if (Ptimer <= 0 && TimerPursuit == false)
            {
                Ptimer = 10;
                Pursuit = false;
            }
            if (Vector3.Distance(transform.position, Target.transform.position) <= 3.0f)
            {
                Stop = true;
                return transform.position;
            }
            else
            {
                Velocity = (transform.position - VLastPos).magnitude * 5;
                m_anim.SetFloat("Speed", Velocity);
                VLastPos = transform.position;
                LastPoint = Destination;
                return Target.transform.position;
            }
        }
        Destination = Waypoints[index];
        LastPoint = Destination;
        //changes the target when close enough
        if (RoundPos(transform.position, Destination.position) == true)
        {
            ClosestPoint = Destination;
            int i = 0;
            foreach (Transform point in Waypoints)
            {
                if (Vector3.Distance(Target.transform.position, point.position) <= Vector3.Distance(Target.transform.position, ClosestPoint.position))
                {
                    ClosestPoint = point;
                    if (ClosestPoint == LastPoint)
                    {
                        index = Random.Range(0, Waypoints.Count - 1);
                        Destination = Waypoints[index];
                        return Destination.position;
                    }
                    index = i;
                    Destination = Waypoints[i];
                    return Destination.position;

                }
                i++;
            }
            index = Random.Range(0, Waypoints.Count - 1);
            Destination = Waypoints[index];

        }
        Velocity = (transform.position - VLastPos).magnitude * 5;
        m_anim.SetFloat("Speed", Velocity);
        VLastPos = transform.position;
        LastPoint = Destination;
        return Destination.position;
    }
}