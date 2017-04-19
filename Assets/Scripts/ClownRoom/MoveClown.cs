using UnityEngine;

public class MoveClown : MonoBehaviour
{
    Transform self;
    Transform target; 
    float moveSpeed = 3;
    float rotationSpeed = 2;

    //A boolean to know if the time should be incremented.
    public bool _timerRun = false;

    //The number of seconds passed since the Doll entered the camera view.
    public float _time = 0;

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
        //Increments the time by deltaTime if the timer is running.
        if (_timerRun)
        {
            _time += Time.deltaTime;
        }

        if (!self.GetComponent<Renderer>().isVisible) // if this object's renderer isn't visible to any cameras (including scene camera)
        {
            self.rotation = Quaternion.Slerp(self.rotation, Quaternion.LookRotation(target.position - self.position), rotationSpeed * Time.deltaTime); // rotate towards player
            //self.position += self.forward * moveSpeed * Time.deltaTime; // move towards player
            _timerRun = true;

            if (_time >= 5)
            {
                self.position = target.position - (target.forward * 2);
                _time = 0;
                _timerRun = false;
            }
        }
        else
        {
            _time = 0;
            _timerRun = false;
        }
    }
}
