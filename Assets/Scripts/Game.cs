using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public BoxCollider spawnZone;
    public GameObject[] spawnTypes;
    public int population = 3;

	void Start () {
        if (spawnZone == null) {
            Debug.LogError("no spawn zone assigned");
            return;
        }
        if (spawnTypes.Length == 0) {
            Debug.LogError("no spawn types assigned");
            return;
        }

        for (int i=0; i<population; i++)
        {
            GameObject prefab = spawnTypes[Random.Range(0,spawnTypes.Length)];
            Vector3 position = new Vector3(
                Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x), 
                0, 
                Random.Range(spawnZone.bounds.min.z, spawnZone.bounds.max.z));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Instantiate(prefab, position, rotation);
        }
	}
	
	void Update () {
	
	}
}
