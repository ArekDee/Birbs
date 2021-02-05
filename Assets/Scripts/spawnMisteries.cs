using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMisteries : MonoBehaviour
{
    [SerializeField] public bool spawn = true;
    public List<GameObject> misteryPrefabs;
    bool first = true;
    public bool secondChance;
    // Start is called before the first frame update

    IEnumerator Start()
    {
        while (spawn)
        {
            
            if (!first)
            {
                yield return new WaitForSeconds(FindObjectOfType<GameController>().spawnMisteriesDelay);
            }
            else
            {
                yield return new WaitForSeconds(FindObjectOfType<GameController>().spawnMisteriesDelay / 2);
            }
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
        attackerIndex = Random.Range(0, misteryPrefabs.Count);
        Spawn(misteryPrefabs[attackerIndex]);

    }

    private void Spawn(GameObject myAttacker)
    {
        GameObject newAttacker = Instantiate
             (myAttacker, transform.position, transform.rotation)
             as GameObject;
        float random = Random.Range(-2, 2f);

        newAttacker.transform.parent = transform;
        newAttacker.transform.position += new Vector3(random, 0, 0);

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
            if (!first)
            {
                yield return new WaitForSeconds(FindObjectOfType<GameController>().spawnMisteriesDelay);
            }
            else
            {
                yield return new WaitForSeconds(FindObjectOfType<GameController>().spawnMisteriesDelay / 2);
            }
            SpawnAttacker();
        }
    }
}
