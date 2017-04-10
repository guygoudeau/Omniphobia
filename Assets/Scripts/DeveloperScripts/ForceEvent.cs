///<summary>
/// Forces all the events that the gamemanager is listening for
/// </summary>

using UnityEngine;
using System.Collections;

public class ForceEvent : Developer
{
    [SerializeField]
    public static ForceEvent instance = null;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        this.isDevMode = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.ToggleDevMode();

        if(this.isDevMode)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                Events.GameStarted.Invoke();
            if (Input.GetKeyDown(KeyCode.X))
                Events.RoomCompleted.Invoke();
            if (Input.GetKeyDown(KeyCode.R))
                Events.GameRestarted.Invoke();
            if (Input.GetKeyDown(KeyCode.C))
                Events.RoomHeightSelected.Invoke();
            if (Input.GetKeyDown(KeyCode.V))
                Events.RoomSpiderSelected.Invoke();
            if (Input.GetKeyDown(KeyCode.B))
                Events.RoomClownSelected.Invoke();
            if (Input.GetKeyDown(KeyCode.N))
                Events.RoomDollSelected.Invoke();
        }
	}
}
