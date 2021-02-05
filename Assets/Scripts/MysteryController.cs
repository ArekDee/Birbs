using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0.0f, 0.0f, -150.0f * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(FindObjectOfType<SaveController>().save.riskTaker < 100)
            {
                FindObjectOfType<SaveController>().save.riskTaker++;
                if (FindObjectOfType<SaveController>().save.riskTaker == 100)
                {
                    FindObjectOfType<PlayServices>().UnlockRiskTakerAchievement();
                }
            }
            if (gameObject.tag == "misterySmall")
            {
                FindObjectOfType<playerMove>().PlayerIsSmaller();
                //FindObjectOfType<GameController>().MisteryActive("small");
                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "misteryBig")
            {
                FindObjectOfType<playerMove>().PlayerIsBigger();
                //FindObjectOfType<GameController>().MisteryActive("big");
                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "misteryReverse")
            {
                FindObjectOfType<playerMove>().PlayerSwitchFly();
                FindObjectOfType<GameController>().MisteryActive("reverse");
                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "misteryCoins")
            {
                FindObjectOfType<GameController>().AddAdditionalCoins();
                //FindObjectOfType<GameController>().MisteryActive("coins");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("cos nie tak...");
            }


        }

    }

    

}
