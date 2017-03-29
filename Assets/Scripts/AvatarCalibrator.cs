using UnityEngine;

public class AvatarCalibrator : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject LeftHandAvatar;

    void Start()
    {
        if (LeftHand == null)
        {
            LeftHand = GameObject.Find("LeftHandAnchor");
        }

        if (LeftHandAvatar == null)
        {
            LeftHandAvatar = transform.FindChild("hand_left").gameObject;
        }
    }

    void Update()
    {
        transform.position += LeftHand.transform.position - LeftHandAvatar.transform.position;
    }
}