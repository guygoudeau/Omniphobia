using UnityEngine;

public class MoveClown : MonoBehaviour
{
    Transform self;
    Transform target; 
    float moveSpeed = 3;
    float rotationSpeed = 2;
    
    void Awake()
    {
        self = this.transform;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!self.GetComponent<Renderer>().isVisible) // if this object's renderer isn't visible to any cameras (including scene camera)
        {
            self.rotation = Quaternion.Slerp(self.rotation, Quaternion.LookRotation(target.position - self.position), rotationSpeed * Time.deltaTime); // rotate towards player
            self.position += self.forward * moveSpeed * Time.deltaTime; // move towards player
        }
    }
}
