using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool isAllive = false;
    float rotation;
    bool switchFly = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllive)
        {
            if (switchFly == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                        Vector3 jump = new Vector3(-3, 4, 0);
                        GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                        rotation = Random.Range(30f, 100f);
                    }
                    else if (Input.mousePosition.x > Screen.width / 2)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                        Vector3 jump = new Vector3(3, 4, 0);
                        GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    Vector3 jump = new Vector3(-3, 4, 0);
                    GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                    rotation = Random.Range(30f, 100f);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    Vector3 jump = new Vector3(3, 4, 0);
                    GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                        Vector3 jump = new Vector3(3, 4, 0);
                        GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                        rotation = Random.Range(30f, 100f);
                    }
                    else if (Input.mousePosition.x > Screen.width / 2)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                        Vector3 jump = new Vector3(-3, 4, 0);
                        GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    Vector3 jump = new Vector3(3, 4, 0);
                    GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                    rotation = Random.Range(30f, 100f);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    Vector3 jump = new Vector3(-3, 4, 0);
                    GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
                }
            }
            if (GetComponent<Transform>().position.x > 3.18)
            {
                GetComponent<Transform>().position = new Vector3(-3.15f, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
            if (GetComponent<Transform>().position.x < -3.18)
            {
                GetComponent<Transform>().position = new Vector3(3.15f, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            }
        }
        GetComponent<Rigidbody2D>().rotation += rotation * Time.deltaTime;
    }
    public void PlayerDie()
    {
        FindObjectOfType<GameController>().PlaySoundOnHit();
        if (!FindObjectOfType<GameController>().testGame)
        {
            isAllive = false;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<CircleCollider2D>().isTrigger = true;
            Vector3 die = new Vector3(0, 6, 0);
            GetComponent<Rigidbody2D>().AddForce(die, ForceMode2D.Impulse);
        }
        
    }
    public void PlayerIsSmaller()
    {
        StartCoroutine("MakeSmall");
    }
    public void PlayerIsBigger()
    {
        StartCoroutine("MakeBig");
    }
    IEnumerator MakeSmall()
    {
        gameObject.transform.localScale -= new Vector3(1.5f, 1.5f, 0);
        yield return new WaitForSeconds(10);
        gameObject.transform.localScale += new Vector3(1.5f, 1.5f, 0);
    }
    IEnumerator MakeBig()
    {
        gameObject.transform.localScale += new Vector3(1.5f, 1.5f, 0);
        yield return new WaitForSeconds(10);
        gameObject.transform.localScale -= new Vector3(1.5f, 1.5f, 0);
    }
    public void PlayerSwitchFly()
    {
        StartCoroutine("SwitchFly");
    }
    IEnumerator SwitchFly()
    {
        switchFly = true;
        yield return new WaitForSeconds(10);
        switchFly = false;
    }

}
