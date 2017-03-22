using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {

    // Player player;
    //Vector3 position;
    public GameObject Target;
    public Vector3 offSet;
    public uint offSetDis;
    public Vector3 LastCheckpoint;
    float Distance;
    public float speed;
    public List<Transform> Waypoints = new List<Transform>();
    public Transform a, b, c, d, e, f;
    public object OCurrent;
    public Transform VCurrent;
    int index;
    bool Reverse;

    private void Start()
    {
        //Waypoints = new SortedList();
        Waypoints = new List<Transform>();
        Waypoints.Add(a);
        Waypoints.Add(b);
        Waypoints.Add(c);
        Waypoints.Add(d);
        Waypoints.Add(e);
        Waypoints.Add(f);
        OCurrent = Waypoints[0];
        Time.timeScale = .5f;
        index = 0;
        Reverse = false;
    }
    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        
        transform.position = WayPoint(transform.position);
        Debug.DrawLine(transform.position, Waypoints[index].position);
        // Changes position to the return value of seek.
        //transform.position = Seek(Target.transform.position, transform.position);
    }

    // Does cool math that moves the enemy toward the target object with an offSet.
    Vector3 Seek(Vector3 CharPos, Vector3 AIPos)
    {
        if (AIPos != (CharPos - offSet))
        {
            AIPos = AIPos + (((CharPos - offSet) - AIPos) * Time.deltaTime);
        }
        return AIPos;
    }
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
        OCurrent = Waypoints[index];
        var dest = Vector3.zero;
        if ((Transform)OCurrent == Waypoints[0])
        {
            VCurrent = a;
            dest = a.position;
        }
        if ((Transform)OCurrent == Waypoints[1])
        {
            VCurrent = b;
            dest = b.position;
        }
        if ((Transform)OCurrent == Waypoints[2])
        {
            VCurrent = c;
            dest = c.position;
        }
        if ((Transform)OCurrent == Waypoints[3])
        {
            VCurrent = d;
            dest = d.position;
        }
        if ((Transform)OCurrent == Waypoints[4])
        {
            VCurrent = e;
            dest = e.position;
        }
        if ((Transform)OCurrent == Waypoints[5])
        {
            VCurrent = f;
            dest = f.position;
        }

        //changes the target when close enough
        if (RoundPos(transform.position, VCurrent.position) == true)
        {
            if (Reverse == false)
            {
                index++;
            }
            
            if (index >= Waypoints.Count)
            {
                Reverse = true;
            }
            if (Reverse == true)
            {
                index--;
            }
            if (index < 0)
            {
                Reverse = false;
            }
        }
        //updates the position of the player.
        //Pos = Pos + ((VCurrent - Pos) * Time.deltaTime);
        float distTraveled = (dest - Pos).magnitude;
        Vector3 displacement = (dest - Pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(VCurrent.position - transform.position), 3.0f * Time.deltaTime);
        Pos += displacement * Time.deltaTime * speed;
        return Pos;
    }
}
