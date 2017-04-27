using UnityEngine;
using System.Collections.Generic;

public class ClownTravel : MonoBehaviour
{
    public List<GameObject> TravelPoints;

    private void Start()
    {
        Events.ClownJumped.AddListener(TravelToNewPosition);
        this.transform.position = TravelPoints[Random.Range(0, TravelPoints.Count - 1)].transform.position;
    }

    void TravelToNewPosition()
    {
        this.transform.position = TravelPoints[Random.Range(0, TravelPoints.Count - 1)].transform.position;
    }

}
