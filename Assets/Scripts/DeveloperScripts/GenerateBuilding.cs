using UnityEngine;
using System.Collections.Generic;

public class GenerateBuilding : MonoBehaviour
{
    public List<GameObject> BuildingPrefabs;
    public List<GameObject> BuildingFoundation;
    public List<List<GameObject>> Buildings;
    public int numFloors;
    
    [ContextMenu("Gen Building")]
    void GenBuilding()
    {
        Buildings = new List<List<GameObject>>();
        foreach(var foundation in BuildingFoundation)
        {
            List<GameObject> Building = new List<GameObject>();
            float lastYPos = 3;
            for (int i = 0; i < numFloors; i++)
            {
                GameObject newFloor = Instantiate(BuildingPrefabs[Random.Range(0, BuildingPrefabs.Count)]);
                newFloor.transform.parent = foundation.transform;
                newFloor.transform.position = foundation.transform.position + new Vector3(0, lastYPos + 15, 0);
                lastYPos = newFloor.transform.position.y;
                Building.Add(newFloor);
            }
            Buildings.Add(Building);
        }
    }

    [ContextMenu("Demo")]
    void DemoCity()
    {
        if(Buildings != null)
        {
            for (int i = 0; i < Buildings.Count; i++)
            {
                for (int j = 0; j < Buildings[i].Count; j++)
                {
                    GameObject temp = Buildings[i][j];
                    Buildings[i].Remove(temp);
                    DestroyImmediate(temp);
                }
            }
        }
    }
}
