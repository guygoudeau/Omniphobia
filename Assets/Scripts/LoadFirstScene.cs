using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        SceneChanger.LoadFirstScene(1);
	}
}
