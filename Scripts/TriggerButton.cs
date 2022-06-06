using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public GameObject buttonPrefab;
    GameObject button;
    bool showButton = false;
    private void Start()
    {
        button = Instantiate(buttonPrefab);
        button.transform.parent = this.transform;
        button.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        button.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        button.SetActive(false);
    }
}
