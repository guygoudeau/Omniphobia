using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeveHeightsSkip : Developer {

    [SerializeField]
    public static DeveHeightsSkip instance = null;
    public GameObject Player;

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
    void Start()
    {
        this.isDevMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        Player = FindObjectOfType<OVRPlayerController>().gameObject;
        this.ToggleDevMode();

        if (this.isDevMode)
        {
            if (SceneManager.GetActiveScene().name == "Heights" && Input.GetKeyDown(KeyCode.U))
                Player.transform.position = new Vector3(-155.19f, 3, -1.199f);
            if (SceneManager.GetActiveScene().name == "Heights" && Input.GetKeyDown(KeyCode.I))
                Player.transform.position = new Vector3(-78.79f, 3, 1.37f);
            if (SceneManager.GetActiveScene().name == "Heights" && Input.GetKeyDown(KeyCode.O))
                Player.transform.position = new Vector3(11.98f, 3, -2.04f);
        }
    }
}
