using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClownScare : MonoBehaviour
{
    Transform target;
    public float MoveDelay;
    public float Timer;
    public bool canJump;
    public float JumpDistance;
    public List<Mesh> ClownMeshes;
    

    private void Start()
    {
        target = FindObjectOfType<PlayerStateSystem>().transform;
        canJump = true;
        Debug.Log(canJump);
        this.GetComponent<MeshFilter>().mesh = ClownMeshes[Random.Range(0, ClownMeshes.Count - 1)];
    }

    private void Update()
    {
        float DistanceBetween = Vector3.Distance(transform.position, target.position);        
        if (DistanceBetween <= 4)
        {
            if (Vector3.Dot(this.transform.position - target.position, target.forward) < 0 && canJump)
            {
                canJump = false;
                this.GetComponent<MeshFilter>().mesh = ClownMeshes[Random.Range(0, ClownMeshes.Count - 1)];
                this.transform.forward = -target.forward;
                this.transform.position = target.position;
                this.transform.position += target.forward * JumpDistance;
                this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);                               
            }                
        }
        Debug.Log(canJump);
        if(canJump == false)
        {
            Timer += Time.deltaTime;
            if (Timer >= MoveDelay)
            {
                canJump = true;
                Timer = 0;
            }
        }
    }
}
