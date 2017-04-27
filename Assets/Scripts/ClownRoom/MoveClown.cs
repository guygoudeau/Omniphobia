using UnityEngine;

public class MoveClown : MonoBehaviour
{
    Transform self;
    public Transform target;
    public NavMeshAgent Clown;
    public bool visible;

    void Awake()
    {
        self = this.transform;
    }

    void Start()
    {
        target = FindObjectOfType<PlayerStateSystem>().transform;
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