using UnityEngine;
using System.Collections;

public class stuff : MonoBehaviour {

    public int CurrentScene = 0;

    // Update is called once per frame
    void Start() {
        SceneChanger.LoadFirstScene(1);
        CurrentScene++;
    }

}
