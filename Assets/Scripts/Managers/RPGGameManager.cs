using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    //RPGCameraManager script
    public RPGCameraManager cameraManager;
    //SpawnPoint script
    public SpawnPoint playerSpawnPoint;
    //singleton instance
    public static RPGGameManager sharedInstance = null;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer(); 
    }

    public void SpawnPlayer()
    {
        //if player point is set -> spawn player and make camera follow player
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }
    void Update()
    {
        //exit game if ESC
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
