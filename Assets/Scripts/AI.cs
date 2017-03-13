using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    // Player player;
    //Vector3 position;
    public GameObject Target;
    public Vector3 offSet;
    //public string Entity;

    // Gets called every frame.
    void Update()
    {
        // Changes position to the return value of seek.
        transform.position = Seek(Target.transform.position, transform.position);
    }

    // Does cool math that moves the enemy toward the target object with an offSet.
    Vector3 Seek(Vector3 a, Vector3 b)
    {
        if ((b != (a - offSet)))
        {
            b = b + (((a - offSet) - b) * Time.deltaTime);
        }
        return b;
    }
}
