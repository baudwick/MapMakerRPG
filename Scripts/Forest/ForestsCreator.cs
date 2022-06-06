using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestsCreator : MonoBehaviour
{
    // Public Properties
    public GameObject[] treeTypes;
    public GameObject[] foilageTypes;
    public enum ForestType { SMALL, MEDIUM, LARGE };

    // Private
    private List<GameObject> forestZones = new List<GameObject>();
    private GameObject terrain;

    // Methods
    public GameObject AddForestZone(ForestData fd)
    {
        GameObject forestZone = new GameObject();
        forestZone.transform.position = new Vector3(fd.location.x, 0, fd.location.z);
        forestZone.AddComponent<ForestData>();
        forestZone.GetComponent<ForestData>().minTreeCount = fd.minTreeCount;
        forestZone.GetComponent<ForestData>().maxTreeCount = fd.maxTreeCount;
        forestZone.GetComponent<ForestData>().minFoliageCount = fd.minFoliageCount;
        forestZone.GetComponent<ForestData>().maxFoliageCount = fd.maxFoliageCount;
        forestZone.GetComponent<ForestData>().bounds = fd.bounds;
        forestZone.GetComponent<ForestData>().location = fd.location;
        forestZones.Add(forestZone);

        return forestZone;
    }

    public void CheckForestZoneLocation(GameObject forestZone)
    {
        float offsetX = forestZone.GetComponent<ForestData>().bounds.x / 2;
        float offsetZ = forestZone.GetComponent<ForestData>().bounds.z / 2;
 
        Vector3 terrainMaxSize = terrain.GetComponent<Terrain>().terrainData.size;
        Vector3 location = forestZone.transform.localPosition;

        // If forest zone is outside of Terrain Bounds, correct zone position.
        if (location.x - (forestZone.GetComponent<ForestData>().bounds.x / 2) < 0)
            location.x += offsetX;
        else if (location.z - (forestZone.GetComponent<ForestData>().bounds.z / 2) < 0)
            location.z += offsetZ;
        else if (location.x + (forestZone.GetComponent<ForestData>().bounds.x / 2) > terrainMaxSize.x)
            location.x -= offsetX;
        else if (location.z + (forestZone.GetComponent<ForestData>().bounds.z / 2) > terrainMaxSize.z)
            location.z -= offsetZ;

        // Update forest zone position
        forestZone.transform.localPosition = location;
    }

    public void AddTrees(GameObject forestZone)
    {
        int totalTrees = UnityEngine.Random.Range(forestZone.GetComponent<ForestData>().minTreeCount, forestZone.GetComponent<ForestData>().maxTreeCount);
        GameObject tree;

        for(int i = 0; i < totalTrees; i++)
        {
            // Adding Forest Zone Location to x and z
            float x = UnityEngine.Random.Range(-forestZone.GetComponent<ForestData>().bounds.x / 2 + GlobalProperties.BOUNDS_BUFFER_ZONE, forestZone.GetComponent<ForestData>().bounds.x / 2 - GlobalProperties.BOUNDS_BUFFER_ZONE);
            float z = UnityEngine.Random.Range(-forestZone.GetComponent<ForestData>().bounds.z / 2 + GlobalProperties.BOUNDS_BUFFER_ZONE, forestZone.GetComponent<ForestData>().bounds.z / 2 - GlobalProperties.BOUNDS_BUFFER_ZONE);
            Vector3 location = forestZone.transform.localPosition;
            x += location.x;
            z += location.z;

            // Small, Medium, Large Tree Size % of time
            int pickTreeSize = UnityEngine.Random.Range(0, 100);
            if (pickTreeSize < 40)
            {
                tree = Instantiate(treeTypes[0], new Vector3(x, 0, z), Quaternion.identity);
                tree.transform.localScale = new Vector3(1, 1, 1);
            }
                
            else if (pickTreeSize < 60)
            {
                tree = Instantiate(treeTypes[1], new Vector3(x, 0, z), Quaternion.identity);
                tree.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
            else
            {
                tree = Instantiate(treeTypes[2], new Vector3(x, 0, z), Quaternion.identity);
                tree.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }

            // Adding it to Parent
            tree.transform.parent = forestZone.transform;
        }
    }

    public void AddFoliage(GameObject forestZone)
    {
        int totalFoliage = UnityEngine.Random.Range(forestZone.GetComponent<ForestData>().minFoliageCount, forestZone.GetComponent<ForestData>().maxFoliageCount);
        GameObject foliage;

        for (int i = 0; i < totalFoliage; i++)
        {
            // Adding Forest Zone Location to x and z
            float x = UnityEngine.Random.Range(-forestZone.GetComponent<ForestData>().bounds.x / 2 + GlobalProperties.BOUNDS_BUFFER_ZONE, forestZone.GetComponent<ForestData>().bounds.x / 2 - GlobalProperties.BOUNDS_BUFFER_ZONE);
            float z = UnityEngine.Random.Range(-forestZone.GetComponent<ForestData>().bounds.z / 2 + GlobalProperties.BOUNDS_BUFFER_ZONE, forestZone.GetComponent<ForestData>().bounds.z / 2 - GlobalProperties.BOUNDS_BUFFER_ZONE);
            Vector3 location = forestZone.transform.position;
            x += location.x;
            z += location.z;

            // Randomly selecting Foilage Type
            int pickFoliageType = UnityEngine.Random.Range(0, foilageTypes.Length);
            foliage = Instantiate(foilageTypes[pickFoliageType], new Vector3(x, 0, z), Quaternion.identity);

            // Adding it to Parent
            foliage.transform.parent = forestZone.transform;
        }
    }

    private void Start()
    {
        terrain = this.GetComponent<MapMaker>().mapTerrain;
    }
}

