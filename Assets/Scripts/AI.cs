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
    public List<Vector3> Waypoints = new List<Vector3>();
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Vector3 d;
    public object OCurrent;
    public Vector3 VCurrent;
    int index;

    private void Start()
    {
        //Waypoints = new SortedList();
        Waypoints = new List<Vector3>();
        Waypoints.Add(a);
        Waypoints.Add(b);
        Waypoints.Add(c);
        Waypoints.Add(d);
        OCurrent = Waypoints[0];
        Time.timeScale = .5f;
    }
    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        
        transform.position = WayPoint(transform.position);
        Debug.DrawLine(transform.position, Waypoints[index]);
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
        /*
        //gets the distance from This object to the Target location.
        Distance = ((Mathf.Abs(Target.x) + Mathf.Abs(Target.y) + Mathf.Abs(Target.z)) / 3)
            - (Mathf.Abs(CurrentPos.x) + Mathf.Abs(CurrentPos.y) + Mathf.Abs(CurrentPos.z)/3);
        //makes sure that distance is positive.
        //checks if this object is close to its target.
        if (Distance <= (offSetDis /2))
        {
            return true;
        }
        
        return false;*/
    }
    Vector3 WayPoint(Vector3 Pos)
    {
        OCurrent = Waypoints[index];
        var dest = Vector3.zero;
        if ((Vector3)OCurrent == Waypoints[0])
        {
            VCurrent = a;
            dest = a;
        }
        if ((Vector3)OCurrent == Waypoints[1])
        {
            VCurrent = b;
            dest = b;
        }
        if ((Vector3)OCurrent == Waypoints[2])
        {
            VCurrent = c;
            dest = c;
        }
        if ((Vector3)OCurrent == Waypoints[3])
        {
            VCurrent = d;
            dest = d;
        }

        //changes the target when close enough
        if (RoundPos(transform.position, VCurrent) == true)
        {
            index++;
            if (index >= Waypoints.Count)
            {
                index = 0;
            }
        }
        //updates the position of the player.
        //Pos = Pos + ((VCurrent - Pos) * Time.deltaTime);
        float distTraveled = (dest - Pos).magnitude;
        Vector3 displacement = (dest - Pos);
        Pos += displacement * Time.deltaTime * speed;
        return Pos;
    }
}
