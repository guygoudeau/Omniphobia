using UnityEngine;
using System.Collections;

public class SceneTransitonTrigger : MonoBehaviour
{
    public string loadScene;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<OVRPlayerController>() != null)
        {
            switch (loadScene)
            {
                case "Heights":
                    Events.RoomHeightSelected.Invoke();
                    break;
                case "Dolls":
                    Events.RoomDollSelected.Invoke();
                    break;
                case "Spiders":
                    Events.RoomSpiderSelected.Invoke();
                    break;
            }
        }
    }
}
