using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherLose : MonoBehaviour
{
    [SerializeField] GameObject feather;
    [SerializeField] public bool spawn = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(FindObjectOfType<GameController>().spawnMisteriesDelay / 2);
            SpawnFeather();
        }
    }
    private void SpawnFeather()
    {
        Spawn(feather);
    }

    private void Spawn(GameObject myAttacker)
    {
        GameObject newAttacker = Instantiate
             (myAttacker, transform.position, Quaternion.identity)
             as GameObject;

    }
}
