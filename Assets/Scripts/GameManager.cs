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
public class GameManager : MonoBehaviour {
    public ScriptableFearList scriptableFears;
    public static GameManager instance = null;
    public GameObject Player;
    public Vector3 Checkpoint;
    public bool Death = false;
  
    Fear Spider = new Fear(0,"Spider");
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

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
       
    // Use this for initialization
    void Start ()
    {
        PlayerStateSystem.OnPlayerDeath.AddListener(PlayerDied);
        List<Fear> FList = new List<Fear>();
        FList.Add(Spider);
        FList.Add(Snake);
        FList.Add(Clown);
        FList.Add(Height);
        FList.Add(Claustrophobia);
        FList.Add(Doll);
        FList.Sort();
        scriptableFears.Create(FList);
     
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    void PlayerDied()
    {
        Player.transform.position = Checkpoint;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerStateSystem.OnPlayerDeath.AddListener(PlayerDied);
    }
}
