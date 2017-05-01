using UnityEngine;
using System.Collections.Generic;

public class SpiderRoomController : MonoBehaviour
{
    List<BossFight> FirePits;

    private void Start()
    {
        FirePits = new List<BossFight>();
        Events.FireLit.AddListener(CheckForVicotry);
        foreach(var pit in FindObjectsOfType<BossFight>())
        {
            FirePits.Add(pit);
        }
    }

    [ContextMenu("force")]
    void CheckForVicotry()
    {
        foreach(var pit in FirePits)
        {
            if (!pit.isEnabled)
                return;
        }
        Events.RoomCompleted.Invoke();
    }
}
