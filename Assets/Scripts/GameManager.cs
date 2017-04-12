///<summary>
/// The GameManager class is will manage the flow between scene transitions 
/// it also keeps track of the number of rooms completed.
/// 
/// Listening to the following events
/// RoomCompleted - Invokes the RoomComplted function
/// RoomHeightSelected - Invokes the HeightRoomSelected function
/// RoomSpiderSelected - Invokes the SpiderRoomSelected function
/// RoomClownSelected - Invokes the ClownRoomSelected function
/// RoomDollSelected - Invokes the DollRoomSelected function
/// 
/// PlayerDeath - Invokes the PlayerDied function
/// 
/// GameStarter - Invokes the RoomCompleted function
/// GameRestarted - Invokes the GameRestarted function
/// 
/// The Fear class contains is what will let us know if a fear room
/// has been completed or not. It also stores the name of the fear
/// 
/// How to add a new fear
/// When adding a new fear create a new instance of the fear call
/// the object must be the name of the fear for clarity
/// In the Start function you will assign the fear its data
/// The name should be the name of the scene the houses the fear room
/// 
/// Once all the fears have been generated we add the too a fear list
/// we will iterate through this list after a room has been completed 
/// once all the fears in the list are completed the game will transition
/// to the victory screen
/// 
/// Any future updates to the game manager must be handled by Dylan
/// </summary>
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Fear
{
    public bool isCompleted;
    public string name;

    public Fear(string name)
    {
        this.name = name;
        this.isCompleted = false;
    }

    public void CompletedStatus(bool status)
    {
        this.isCompleted = status;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Vector3 Checkpoint;
    public ScriptableFearList scriptableFears;    
    private Fear currentFear = null;

    Fear Spider;
    Fear Clown;
    Fear Height;
    Fear Doll;

    public List<Fear> fearList;

    void Awake()
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

    void Start()
    {
        Events.PlayerDeath.AddListener(PlayerDied);

        Events.RoomCompleted.AddListener(RoomCompleted);
        Events.RoomHeightSelected.AddListener(HeightRoomSelected);
        Events.RoomSpiderSelected.AddListener(SpiderRoomSelected);
        Events.RoomClownSelected.AddListener(ClownRoomSelected);
        Events.RoomDollSelected.AddListener(DollRoomSelected);

        Events.GameStarted.AddListener(RoomCompleted);
        Events.GameRestarted.AddListener(GameRestarted);

        Spider = new Fear("Rory");
        Clown = new Fear("Clowns");
        Height = new Fear("Heights");
        Doll = new Fear("Dolls");

        this.fearList = new List<Fear>();
        this.fearList.Add(Spider);
        this.fearList.Add(Clown);
        this.fearList.Add(Height);
        this.fearList.Add(Doll);        
    }

    void GameRestarted()
    {
        SceneManager.LoadScene("Menu");
        foreach (var fear in this.fearList)
        {
            fear.CompletedStatus(false);
        }
        currentFear = null;
    }

    bool VictoryCheck()
    {
        foreach(var fear in this.fearList)
        {
            if (!fear.isCompleted)
                return false;
        }
        return true;
    }

    void HeightRoomSelected()
    {
        if (currentFear == null)
        {
            SceneManager.LoadScene(this.Height.name);
            this.currentFear = this.Height;
        }
    }

    void ClownRoomSelected()
    {
        if (currentFear == null)
        {
            SceneManager.LoadScene(this.Clown.name);
            this.currentFear = this.Clown;
        }
    }

    void SpiderRoomSelected()
    {
        if(currentFear == null)
        {
            SceneManager.LoadScene(this.Spider.name);
            this.currentFear = this.Spider;
        }        
    }

    void DollRoomSelected()
    {
        if (currentFear == null)
        {
            SceneManager.LoadScene(this.Doll.name);
            this.currentFear = this.Doll;
        }
    }

    void RoomCompleted()
    {
        if (currentFear != null)
        {
            this.currentFear.CompletedStatus(true);
            this.currentFear = null;
        }
        if(!VictoryCheck())
            SceneManager.LoadScene("LibraryHub");
        else
            SceneManager.LoadScene("Win");
    }

    void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
