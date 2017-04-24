using UnityEngine;

public class MoveClown : MonoBehaviour
{
    Transform self;
    Transform target;
    NavMeshAgent Clown;
    float moveSpeed = 3;
    float rotationSpeed = 2;
    public bool visible;
    public Vector3 targetPosition;

    void Awake()
    {
        self = this.transform;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        Clown = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!self.GetComponent<Renderer>().isVisible) // if this object's renderer isn't visible to any cameras (including scene camera)
        {
            visible = false;
            Clown.destination = target.position; // seek player
        }
        else
        {
            visible = true;
            Clown.destination = self.position;
        }
    }
}