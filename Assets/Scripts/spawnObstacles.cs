using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    [SerializeField] public bool spawn = true;
    public List<GameObject> attackerPrefabs;
    public int i = 0;
    public bool secondChance;
    float beforeRandom = 0f;
    // Start is called before the first frame update
    
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(FindObjectOfType<GameController>().GetSpawnDelay());
            if(i == 20 || i == 130)
            {
                yield return new WaitForSeconds(FindObjectOfType<GameController>().GetSpawnDelay());
            }
            i++;
            if (secondChance)
            {
                yield break;
            }
            SpawnAttacker();
        }
    }
    private void SpawnAttacker()
    {
        int attackerIndex;
        if (i <= 20)
        {
            attackerIndex = UnityEngine.Random.Range(0, 3);
            Spawn(attackerPrefabs[attackerIndex]);
        }
        else if (i > 20 && i <= 40)
        {
            attackerIndex = 3;
            Spawn(attackerPrefabs[attackerIndex]);
        }
        else if (i > 40 && i <= 130)
        {
            attackerIndex = UnityEngine.Random.Range(3, 7);
            Spawn(attackerPrefabs[attackerIndex]);
        }
        else if(i > 130)
        {
            attackerIndex = 7;
            Spawn(attackerPrefabs[attackerIndex]);
        }
        
    }

    private void Spawn(GameObject myAttacker)
    {
        GameObject newAttacker = Instantiate
             (myAttacker, transform.position, transform.rotation)
             as GameObject;
        newAttacker.transform.parent = transform;
        float random = UnityEngine.Random.Range(0f, 2.45f);
        while(Math.Abs(beforeRandom - random) < 0.2)
        {
            random = UnityEngine.Random.Range(0f, 2.45f);
        }
        beforeRandom = random;
        newAttacker.transform.GetChild(2).transform.localPosition = new Vector3(-5.05f + random, 0, 0); 
        newAttacker.transform.GetChild(0).transform.localPosition = new Vector3(2.6f + random, 0, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawnAfterRestart()
    {
        StartCoroutine(StartSpawn());
    } 
    IEnumerator StartSpawn()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(FindObjectOfType<GameController>().GetSpawnDelay());
            if (i == 20 || i == 40 || i == 130)
            {
                yield return new WaitForSeconds(FindObjectOfType<GameController>().GetSpawnDelay());
            }
            i++;
            SpawnAttacker();
        }
    }
}
