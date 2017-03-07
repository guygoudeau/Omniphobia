using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventPlayerDeath : UnityEvent
{

}
public class EventPlayerWin : UnityEvent
{

}
public class PlayerStateSystem : MonoBehaviour {
    public static EventPlayerDeath OnPlayerDeath;
    public static EventPlayerWin OnPlayerWin;
    private void Awake()
    {
        OnPlayerWin = new EventPlayerWin();
        OnPlayerDeath = new EventPlayerDeath();
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerDeath.Invoke();

        }
        if (transform.position.y <= -200)
        {
            OnPlayerDeath.Invoke();
        }
        

}
}
