using System.Collections;
using UnityEngine;

public class BuildingSpawnManager : MonoBehaviour
{
    public GameObject buildingPrefab1;
    public GameObject buildingPrefab2;
    public Transform player;
    public float spawnDistance = 50f;
    public float destroyDistance = 10f;

    private void Start()
    {
        StartCoroutine(SpawnBuildings());
    }

    IEnumerator SpawnBuildings()
    {
        while (true)
        {
            if (player.position.z > spawnDistance)
            {
                SpawnBuilding();
            }

            yield return null;
        }
    }

    void SpawnBuilding()
    {
        float randomX = Random.Range(-5f, 5f); 
        Vector3 spawnPosition = new Vector3(randomX, 0f, player.position.z + spawnDistance);

        GameObject newBuilding = Instantiate(RandomBuildingPrefab(), spawnPosition, Quaternion.identity);

       
        StartCoroutine(DestroyBuilding(newBuilding, player.position.z - destroyDistance));
    }

    GameObject RandomBuildingPrefab()
    {
        return Random.Range(0, 2) == 0 ? buildingPrefab1 : buildingPrefab2;
    }

    IEnumerator DestroyBuilding(GameObject building, float destroyPosition)
    {
        while (building.transform.position.z < destroyPosition)
        {
            yield return null;
        }

        Destroy(building);
    }
}
