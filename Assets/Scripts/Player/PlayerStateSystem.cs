using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateSystem : MonoBehaviour
{
    public bool isKillable;

    private void Awake()
    {
        this.isKillable = false;        
    }

    void Start()
    {
        Events.PlayerCanDie.AddListener(CanBeKilled);
        Events.PlayerCantDie.AddListener(CantBeKilled);
        Events.PlayerEnteredKillBox.AddListener(EnteredKillVolume);
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

    void CantBeKilled()
    {
        this.isKillable = false;        
    }
}
