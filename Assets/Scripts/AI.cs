using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    // Player player;
    //Vector3 position;
    public GameObject Target;
    public Vector3 offSet;
    public uint offSetDis;
    public Vector3 LastCheckpoint;
    float Distance;
    public float speed;
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Vector3 d;


    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        
        transform.position = WayPoint(transform.position);
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
    Vector3 RoundPos(Vector3 NewTarget, Vector3 CurrentPos, Vector3 Target)
    {
        //gets the distance from This object to the Target location.
        Distance = ((Target.x + Target.y + Target.z) / 3);
        //makes sure that distance is positive.
        if (Distance <= 0)
        {
            Distance = -Distance;
        }
        //checks if this object is close to its target.
        if (Distance <= (offSetDis))
        {
            return NewTarget;
        }
        else
        return CurrentPos;
    }
    Vector3 WayPoint(Vector3 Pos)
    {
        if (LastCheckpoint == a)
        {
            if (Pos != b)
            {
                Pos = Pos + ((b - Pos) * Time.deltaTime * speed);
                Pos = RoundPos(b, Pos, transform.position);
            }
            else
            {
                LastCheckpoint = b;
            }

            return Pos;
        }
        if (LastCheckpoint == b)
        {
            if (Pos != c)
            {
                Pos = Pos + ((c - Pos) * Time.deltaTime * speed);
                Pos = RoundPos(c, Pos, transform.position);
            }
            else
            {
                LastCheckpoint = c;
            }

            return Pos;
        }
        if (LastCheckpoint == c)
        {
            if (Pos != d)
            {
                Pos = Pos + ((d - Pos) * Time.deltaTime * speed);
                Pos = RoundPos(d, Pos, transform.position);
            }
            else
            {
                LastCheckpoint = d;
            }

            return Pos;
        }
        if (LastCheckpoint == d)
        {
            if (Pos != a)
            {
                Pos = Pos + ((a - Pos) * Time.deltaTime * speed);
                Pos = RoundPos(a, Pos, transform.position);
            }
            else
            {
                LastCheckpoint = a;
            }

            return Pos;
        }
        //Keeps LastChecpoint from being null
        LastCheckpoint = a;
        return Pos;
    }
}
