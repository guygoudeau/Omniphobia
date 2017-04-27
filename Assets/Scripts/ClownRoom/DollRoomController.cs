using UnityEngine;
using System.Collections.Generic;

public class DollRoomController : MonoBehaviour
{
    public GameObject ClownPrefab;
    public Transform ClownSpawn;
    public List<GameObject> KeyPrefabs;
    public List<Transform> KeySpawns;
	// Use this for initialization
	void Start ()
    {
        Events.SpawnClown.AddListener(SpawnClown);
	}

    void SpawnClown()
    {
        GetComponent<AudioSource>().Play();
        var newClown = Instantiate(ClownPrefab);
        newClown.transform.position = ClownSpawn.position;
        newClown.transform.position = new Vector3(newClown.transform.position.x, 0, newClown.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerStateSystem>())
        {
            foreach(var key in KeyPrefabs)
            {
                var newKey = Instantiate(key);
                newKey.transform.position = KeySpawns[KeyPrefabs.IndexOf(key)].position;
            }
            Destroy(GetComponent<BoxCollider>());    
        }
    }
}
