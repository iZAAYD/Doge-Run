using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platforms;
    public Transform cameraPos;

    private float platformWidth;
    private GameObject currentPlatform, nextPlatform, lastPlatform, movedPlatform;
    private void Start()
    {
        platformWidth = platforms[0].GetComponent<BoxCollider2D>().size.x;
        currentPlatform = platforms[0];
        nextPlatform = platforms[1];
        lastPlatform = platforms[2];
        
    }

    private void Update()
    {
        
        if (cameraPos.position.x >= nextPlatform.transform.position.x)
        {
            currentPlatform.transform.position = new Vector2(lastPlatform.transform.position.x + platformWidth, currentPlatform.transform.position.y);
            movedPlatform = currentPlatform;
            currentPlatform = nextPlatform;
            nextPlatform = lastPlatform;
            lastPlatform = movedPlatform;
           
        }
    }
}
