using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject Player;
    public Transform Checkpoint;
    public struct Fear
    {
        public int value;
        public string name;

        public Fear(int value, string name)
        {
            this.name = name;
            this.value = value;
        }
    }
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
    }
    // Use this for initialization
    void Start ()
    {

       
    }

    // Update is called once per frame
    void Update()
    {


    }
}
