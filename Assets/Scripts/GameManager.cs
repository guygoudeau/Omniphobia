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

    public void Completed()
    {
        this.isCompleted = true;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Vector3 Checkpoint;
    public ScriptableFearList scriptableFears;    
    public int level;
    public Fear currentFear = null;

    Fear Spider;
    Fear Clown;
    Fear Height;
    Fear Doll;

    List<Fear> fearList;

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
        level = 0;

        Events.PlayerWin.AddListener(PlayerWon);
        Events.PlayerDeath.AddListener(PlayerDied);
        Events.PlayerForceScene.AddListener(NextLevel);

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

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            level = 0;
        }
    }

    void GameRestarted()
    {
        SceneManager.LoadScene("Menu");
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
            this.currentFear.Completed();
            this.currentFear = null;
        }
        if(!VictoryCheck())
            SceneManager.LoadScene("LibraryHub");
        else
            SceneManager.LoadScene("Win");
    }

    void PlayerWon()
    {
        //StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(3));
        SceneManager.LoadScene("Win");
    }

    void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        level++;
        if (level > 3)
        {
            level = 0;
        }

        SceneManager.LoadScene(level);
    }
}
