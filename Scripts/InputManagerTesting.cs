using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerTesting : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject mapCamera;
    public GameObject player;

    bool mapMakingActive = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Enter 2D Map Mode to add forest
        if(Input.GetKeyDown(KeyCode.C) && !mapMakingActive)
        {
            mapCanvas.SetActive(true);
            mapCamera.SetActive(true);
            player.SetActive(false);
            mapMakingActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else if (Input.GetKeyDown(KeyCode.C) && mapMakingActive)
        {
            mapCanvas.SetActive(false);
            mapCamera.SetActive(false);
            player.SetActive(true);
            mapMakingActive = false;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
