using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapMaker : MonoBehaviour
{
    public GameObject[] mapSymbols;
    public GameObject mapTerrain;
    public GameObject player;
    public GameObject mapCanvas;
    public GameObject mapCamera;

    int counter = 0;
    string currentMapIcon = "";
    Vector3 currentMapPosition = new Vector3();
    Vector3 currentTerrainPosion = new Vector3();
    ForestsCreator fc;

    ForestData fd = new ForestData();
    List<GameObject> forestZones = new List<GameObject>();

    private void Start()
    {
        fc = this.GetComponent<ForestsCreator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);

                if (hit.transform.name == "MapHitTarget")
                {
                    currentMapPosition = new Vector3(hit.point.x, hit.point.y, 3.5f);
                    
                    // Translating UV to 3D Coordinates based on 1:1 with Texture and Terrain Size
                    Vector2 mapUVCoord = hit.textureCoord;
                    Texture2D mapTexture = hit.transform.gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
                    mapUVCoord.x *= mapTexture.width;
                    mapUVCoord.y *= mapTexture.height;

                    currentTerrainPosion = new Vector3(mapUVCoord.x, 0, mapUVCoord.y);

                    AddMapIcon();
                    BuildForestData();
                }
            }
        }
    }

    public void ButtonSelected()
    {
        currentMapIcon = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(currentMapIcon);
    }

    public void ButtonCreateForests()
    {
        foreach(GameObject forestZone in forestZones)
        {
            forestZone.name = "Forest_Zone_" + counter;
            fc.CheckForestZoneLocation(forestZone);
            fc.AddTrees(forestZone);
            fc.AddFoliage(forestZone);
            counter++;
        }
    }

    public void PlacePlayer()
    {
        mapCanvas.SetActive(false);
        mapCamera.SetActive(false);
        player.SetActive(true);

        player.transform.position = new Vector3(10, 0.8f, 10);
    }

    void AddMapIcon()
    {
        if (currentMapIcon == GlobalProperties.BUTTON_FOREST_SMALL)
            Instantiate(mapSymbols[0], currentMapPosition, Quaternion.identity);
        else if (currentMapIcon == GlobalProperties.BUTTON_FOREST_MEDIUM)
            Instantiate(mapSymbols[1], currentMapPosition, Quaternion.identity);
        else if (currentMapIcon == GlobalProperties.BUTTON_FOREST_LARGE)
            Instantiate(mapSymbols[2], currentMapPosition, Quaternion.identity);    
    }

    public void BuildForestData()
    {
        if (currentMapIcon == GlobalProperties.BUTTON_FOREST_SMALL)
        {
            fd.minTreeCount = GlobalProperties.FOREST_SMALL_TREE_MIN_COUNT;
            fd.maxTreeCount = GlobalProperties.FOREST_SMALL_TREE_MAX_COUNT;
            fd.minFoliageCount = GlobalProperties.FOREST_SMALL_FOLIAGE_MIN_COUNT;
            fd.maxFoliageCount = GlobalProperties.FOREST_SMALL_FOLIAGE_MAX_COUNT;
            fd.bounds = GlobalProperties.FOREST_SMALL_BOUNDS;
            fd.location = currentTerrainPosion;
            forestZones.Add(fc.AddForestZone(fd));
        }

        else if (currentMapIcon == GlobalProperties.BUTTON_FOREST_MEDIUM)
        {
            fd.minTreeCount = GlobalProperties.FOREST_MEDIUM_TREE_MIN_COUNT;
            fd.maxTreeCount = GlobalProperties.FOREST_MEDIUM_TREE_MAX_COUNT;
            fd.minFoliageCount = GlobalProperties.FOREST_MEDIUM_FOLIAGE_MIN_COUNT;
            fd.maxFoliageCount = GlobalProperties.FOREST_MEDIUM_FOLIAGE_MAX_COUNT;
            fd.bounds = GlobalProperties.FOREST_MEDIUM_BOUNDS;
            fd.location = currentTerrainPosion;
            forestZones.Add(fc.AddForestZone(fd));
        }

        else if (currentMapIcon == GlobalProperties.BUTTON_FOREST_LARGE)
        {
            fd.minTreeCount = GlobalProperties.FOREST_LARGE_TREE_MIN_COUNT;
            fd.maxTreeCount = GlobalProperties.FOREST_LARGE_TREE_MAX_COUNT;
            fd.minFoliageCount = GlobalProperties.FOREST_LARGE_FOLIAGE_MIN_COUNT;
            fd.maxFoliageCount = GlobalProperties.FOREST_LARGE_FOLIAGE_MAX_COUNT;
            fd.bounds = GlobalProperties.FOREST_LARGE_BOUNDS;
            fd.location = currentTerrainPosion;
            forestZones.Add(fc.AddForestZone(fd));
        }
    }
}
