using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveMistery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitAndDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        transform.Translate(FindObjectOfType<GameController>().spawnMisteriesSpeed * deltaTime, Space.Self);
    }
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
    }
}
