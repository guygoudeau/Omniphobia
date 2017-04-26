using UnityEngine;
using System.Collections;

public class ClownScare : MonoBehaviour
{
    Transform target;
    public float MoveDelay;
    private void Start()
    {
        target = FindObjectOfType<PlayerStateSystem>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 2)
        {
            Vector3 lookDir = target.position - transform.position;

            Vector3 myDir = transform.forward;
            Vector3 yourDir = target.forward;

            float myAngle = Vector3.Angle(myDir, lookDir);
            float yourAngle = Vector3.Angle(yourDir, -lookDir);
            Debug.Log(myAngle + "my");
            Debug.Log(yourAngle + "you");
            //Debug.Log(Vector3.Dot(this.transform.position - target.position, target.forward));
            //Debug.Log(this.transform.forward == target.forward);

            if (Vector3.Dot(this.transform.position - target.position, target.forward) < 0 )
            {
                if (myAngle > 100.0f && yourAngle > 100.0f)
                {
                    this.transform.position = target.position + (transform.position - target.position) + target.forward;
                    this.transform.forward = -target.forward;
                }           
            }
        }
    }
}
