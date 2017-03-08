using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Fear
{
    public int value;
    public string name;

    public Fear(int value, string name)
    {
        this.name = name;
        this.value = value;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public ScriptableFearList scriptableFears;
    public GameObject Player;
    public Vector3 Checkpoint;

    Fear Spider = new Fear(0, "Spider");
    Fear Snake = new Fear(0, "Snake");
    Fear Clown = new Fear(2, "Clown");
    Fear Height = new Fear(0, "Height");
    Fear Claustrophobia = new Fear(0, "Claustrophobia");
    Fear Doll = new Fear(0, "Doll");

    public string Checkup()
    {
        List<Fear> FList = new List<Fear>();
        FList.Add(Spider);
        FList.Add(Snake);
        FList.Add(Clown);
        FList.Add(Height);
        FList.Add(Claustrophobia);
        FList.Add(Doll);
        FList.Sort();
        return FList[0].name;
    }

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
    int level;
    void Start()
    {
        level = 0;
        Events.PlayerWin.AddListener(PlayerWon);
        Events.PlayerDeath.AddListener(PlayerDied);
        Events.PlayerReloadScene.AddListener(PlayerReloaded);
        Events.PlayerForceScene.AddListener(NextLevel);

        List<Fear> FList = new List<Fear>();
        FList.Add(Spider);
        FList.Add(Snake);
        FList.Add(Clown);
        FList.Add(Height);
        FList.Add(Claustrophobia);
        FList.Add(Doll);
        FList.Sort((a,b)=> a.value.CompareTo(b.value));
        scriptableFears.Create(FList);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            level = 0;
        }
    }

    void Update()
    {

    }

    void PlayerWon()
    {
        StartCoroutine(FindObjectOfType<AlphaFade>().FadeIn(3));
    }

    void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PlayerReloaded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        level++;
        Debug.Log("nextlvl " + level);
        if (level > 3)
            level = 0;

        SceneManager.LoadScene(level);





    }
}
