using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    // Player player;
    //Vector3 position;
    public GameObject Target;
    //public string Entity;

    void Update()
    {
        transform.position = Seek(Target.transform.position, transform.position);
    }

    Vector3 Seek(Vector3 a, Vector3 b)
    {
        if ((b != a))
        {
            b = b + ((a - b) * Time.deltaTime);
        }
        return b;
    }
}
