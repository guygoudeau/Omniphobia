using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    // Player player;
    //Vector3 position;
    public GameObject Target;
    public Vector3 offSet;
    public float offSetDis;
    public Vector3 current;
    float Distance;
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Vector3 d;


    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        // Changes position to the return value of seek.
        transform.position = WayPoint(transform.position);
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
    Vector3 RoundPos(Vector3 Target, Vector3 CurrentPos)
    {
        Distance = ((CurrentPos.x + CurrentPos.y + CurrentPos.z) / 3);
        if (Distance <= (Distance - offSetDis) && Distance >= (Distance + offSetDis))
        {
            return Target;
        }
        else
        return CurrentPos;
    }
    Vector3 WayPoint(Vector3 Pos)
    { 
        if (current == a)
        {
            if (Pos != b)
            {
                Pos = Pos + ((b - Pos) * Time.deltaTime);
                RoundPos(b, transform.position);
            }
            else
            {
                current = b;
                //offSetDis = ((offSet.x + offSet.y + offSet.z)/3);
            }

            return Pos;
        }
        else if (current == b)
        {
            if (Pos != c)
            {
                Pos = Pos + (((c - offSet) - Pos) * Time.deltaTime);
                RoundPos(c, transform.position);
            }
            else
            {
                current = c;
                //offSetDis = ((offSet.x + offSet.y + offSet.z) / 3);
            }

            return Pos;
        }
        else if (current == c)
        {
            if (Pos != (d - offSet))
            {
                Pos = Pos + (((d - offSet) - Pos) * Time.deltaTime);
                RoundPos(d, transform.position);
            }
            else
            {
                current = d;
                //offSetDis = ((offSet.x + offSet.y + offSet.z) / 3);
            }

            return Pos;
        }
        else
        {
            if (Pos != (a - offSet))
            {
                Pos = Pos + (((a - offSet) - Pos) * Time.deltaTime);
                RoundPos(a, transform.position);
            }
            else
            {
                current = a;
                //offSetDis = ((offSet.x + offSet.y + offSet.z) / 3);
            }

            return Pos;
        }
    }
}
