using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger{

    static int Current;

    static public void LoadFirstScene(int m_FirstScene)
    {
        SceneManager.LoadScene(m_FirstScene, LoadSceneMode.Additive);
        Current = m_FirstScene;
    }

    static public void ChangeScene(GameObject m_Player, int m_Scene)
    {
        SceneManager.LoadScene(m_Scene, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(m_Player, SceneManager.GetSceneAt(m_Scene));
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(m_Scene));
        SceneManager.UnloadScene(Current);
        Current = m_Scene;
    }
}
