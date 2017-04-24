using UnityEngine;
using System.Collections.Generic;

public class GenerateBuilding : MonoBehaviour
{
    public List<GameObject> BuildingPrefabs;
    public List<GameObject> BuildingRoofs;
    public List<GameObject> BuildingFoundation;
    public bool genLikeBuildings;        

    [ContextMenu("Gen Building")]
    void GenBuilding()
    {        
        foreach(var foundation in BuildingFoundation)
        {
            int numFloors = Random.Range(10, 20);
            List<GameObject> Building = new List<GameObject>();
            int prefabindex = 0;
            if (genLikeBuildings)
            {
                foreach(var obj in BuildingPrefabs)
                {
                    if(obj.tag == foundation.tag)
                    {
                        prefabindex = BuildingPrefabs.IndexOf(obj);
                    }
                }
            }
            float lastYPos = 3;
            for (int i = 0; i < numFloors; i++)
            {
                GameObject newFloor;
                if(!genLikeBuildings)
                    newFloor = Instantiate(BuildingPrefabs[Random.Range(0, BuildingPrefabs.Count)]);
                else
                    newFloor = Instantiate(BuildingPrefabs[prefabindex]);
                newFloor.transform.parent = foundation.transform;
                newFloor.transform.position = foundation.transform.position + new Vector3(0, lastYPos + 15, 0);
                lastYPos = newFloor.transform.position.y;
                newFloor.GetComponent<ColliderToFit>().FitColliderToChildren();
                Building.Add(newFloor);
            }
            GameObject roof;
            if (genLikeBuildings)
            {
                foreach (var obj in BuildingRoofs)
                {
                    if (obj.tag == foundation.tag)
                    {
                        prefabindex = BuildingRoofs.IndexOf(obj);
                    }
                }
            }
            if (!genLikeBuildings)
                roof = Instantiate(BuildingRoofs[Random.Range(0, BuildingRoofs.Count)]);
            else
                roof = Instantiate(BuildingRoofs[prefabindex]);
            roof.transform.parent = foundation.transform;
            roof.transform.position = foundation.transform.position + new Vector3(0, lastYPos + 15, 0);
            roof.GetComponent<ColliderToFit>().FitColliderToChildren();
            Building.Add(roof);
            foundation.transform.localScale = new Vector3(4, 4, 4);
        }
    }

    [ContextMenu("Demo")]
    void DemoCity()
    {
        foreach(var building in BuildingFoundation)
        {
            foreach(var floor in building.GetComponentsInChildren<Rigidbody>())
            {
                DestroyImmediate(floor.gameObject);
            }
        }     
    }
}
