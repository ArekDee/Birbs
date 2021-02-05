using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> playerPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlayer(string name)
    {
        GameObject player = FindBirdByName(name);
        if (player != null)
        {
            GameObject newPlayer = Instantiate
             (player, transform.position, transform.rotation)
             as GameObject;
            newPlayer.transform.parent = transform;
        }
    }

    private GameObject FindBirdByName(string name)
    {
        if (name == "commonCock")
        {
            return playerPrefabs[0];
        }
        if (name == "robin")
        {
            return playerPrefabs[1];
        }
        if (name == "seagull")
        {
            return playerPrefabs[2];
        }
        if (name == "bullfinch")
        {
            return playerPrefabs[3];
        }
        if (name == "jackdaw")
        {
            return playerPrefabs[4];
        }
        if (name == "greattit")
        {
            return playerPrefabs[5];
        }
        if (name == "emperorpenguin")
        {
            return playerPrefabs[6];
        }
        if (name == "hoopoe")
        {
            return playerPrefabs[7];
        }
        if (name == "sparrow")
        {
            return playerPrefabs[8];
        }
        if (name == "cptnsparrow")
        {
            return playerPrefabs[9];
        }
        if (name == "stork")
        {
            return playerPrefabs[10];
        }
        if (name == "flamingo")
        {
            return playerPrefabs[11];
        }
        if (name == "peacock")
        {
            return playerPrefabs[12];
        }
        if (name == "raven")
        {
            return playerPrefabs[13];
        }
        if (name == "dragon")
        {
            return playerPrefabs[14];
        }
        if (name == "eagle")
        {
            return playerPrefabs[15];
        }
        return null;
    }
}
