using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionsUI : MonoBehaviour {

    public string DisplayInfo;
    public GameObject Player;
    public GameObject Canvas;
    public Text Instructions;
   float Timer = 10;
    bool on;
    
	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<CharacterController>().gameObject;
        foreach (Transform a in Player.transform)
        {
            if (a.tag == "Canvas")
            {
               Canvas = a.gameObject;
            }
        }
        foreach (Transform b in Canvas.GetComponentsInChildren<Transform>())
        {
            Instructions = b.GetComponent<Text>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (on == true)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
             Instructions.text = "";
            on = false;

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other = Player.GetComponent<CharacterController>())
        Instructions.text = DisplayInfo;
        Timer = 10;
        on = true;



    }
}
