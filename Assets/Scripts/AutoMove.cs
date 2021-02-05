using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
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
        transform.Translate(FindObjectOfType<GameController>().GetSpawnSpeed() * deltaTime, Space.Self);
    }
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
