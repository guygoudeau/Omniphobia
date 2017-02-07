using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    int snakes = 0;
    int spiders = 0;
    int heights = 0;
    int claustrophobia = 0;
    int publicSpeaking = 0;
    public List<int> Fears;
    

    // Use this for initialization
    void Start () {
        Fears.Add(snakes);
        Fears.Add(spiders);
        Fears.Add(heights);
        Fears.Add(claustrophobia);
        Fears.Add(publicSpeaking);

    }
	
	// Update is called once per frame
	void Update () {
    if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.B))
        {
            
            Debug.Log(Fears[0]);
            Debug.Log(Fears[4]);
        }
        if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.A))
        {

            snakes++;
            Debug.Log(snakes);
            
        }

    }
}
