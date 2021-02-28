using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiwiDeath : MonoBehaviour
{
    [SerializeField]GameObject deadKiwi;
    bool thrown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            if (thrown == false)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                SpawnDeadKiwi();
                thrown = true;
            }
        }
    }
    private void SpawnDeadKiwi()
    {
        Spawn(deadKiwi);
    }

    private void Spawn(GameObject deadKiwi)
    {
        GameObject newAttacker = Instantiate
             (deadKiwi, transform.position, Quaternion.identity)
             as GameObject;
        Vector2 throwKiwi = new Vector2(-3, 8);
        newAttacker.GetComponent<Rigidbody2D>().AddForce(throwKiwi, ForceMode2D.Impulse);

        newAttacker = Instantiate
             (deadKiwi, transform.position, Quaternion.identity)
             as GameObject;
        throwKiwi = new Vector2(2, 10);
        newAttacker.GetComponent<Rigidbody2D>().AddForce(throwKiwi, ForceMode2D.Impulse);
    }
}
