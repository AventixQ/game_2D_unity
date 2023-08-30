using UnityEngine;
public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float repeatInterval; //interval in which object should be spawned

    public void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
        }
    }

    public GameObject SpawnObject()
    {
        if (prefabToSpawn != null) //if ToSpawn is assigned
        {
            //instantiate the prefab at the spawn point's position with no rotation
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}