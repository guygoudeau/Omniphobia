///<summary>
/// Base class for any developerscript class
/// Anytime we need to create a new develper script
/// it must inherit from this script. This will allow us
/// to itterate through them if needed.
/// This will handle turning dev mode on and off
/// All Scripts that inherit from this class must also be placed
/// on the DeveloperScripts prefab. The object is a singleton and is 
/// located in the Menu scene
/// </summary>

using UnityEngine;
using System.Collections;

public class Developer : MonoBehaviour
{
    [SerializeField]
    protected bool isDevMode;
    public static ForceEvent instance = null;

    // Use this for initialization
    void Start ()
    {
        this.isDevMode = false;
	}

    protected void ToggleDevMode()
    {
        if(Input.GetKeyDown(KeyCode.P))
            this.isDevMode = !this.isDevMode;
    }
}
