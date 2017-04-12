using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateSystem : MonoBehaviour
{
    public bool isKillable;
    public bool isMotionControlled;

    private void Awake()
    {
        this.isKillable = false;        
    }

    void Start()
    {
        Events.PlayerCanDie.AddListener(CanBeKilled);
        Events.PlayerCantDie.AddListener(CantBeKilled);
        Events.PlayerEnteredKillBox.AddListener(EnteredKillVolume);
        Events.PlayerMovementChange.AddListener(ChangeMovement);
    }

    private void Update()
    {        
        if (!isMotionControlled)
        {
            GetComponent<OVRPlayerController>().Acceleration = 0;
        }
        else
        {
            GetComponent<OVRPlayerController>().Acceleration = 0.3f;
        }
    }

    void EnteredKillVolume()
    {
        if(this.isKillable)
            Events.PlayerDeath.Invoke();
    }

    void CanBeKilled()
    {
        this.isKillable = true;       
    }

    void ChangeMovement()
    {
        isMotionControlled = !isMotionControlled;
    }

    void CantBeKilled()
    {
        this.isKillable = false;        
    }
}
