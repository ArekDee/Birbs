using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!FindObjectOfType<SaveController>().save.firstgame)
            {
                
                FindObjectOfType<PlayServices>().UnlockFirstTryAchievement();
            }
            if (FindObjectOfType<SaveController>().save.neverGiveUp < 200)
            {
                FindObjectOfType<SaveController>().save.neverGiveUp++;
                if(FindObjectOfType<SaveController>().save.neverGiveUp == 200)
                {
                    FindObjectOfType<PlayServices>().UnlockNeverGiveUpAchievement();
                }
                PlayerPrefs.SetInt(Save.NEVER_GIVE_UP, FindObjectOfType<SaveController>().save.neverGiveUp);
            }
            FindObjectOfType<playerMove>().PlayerDie();
            FindObjectOfType<GameController>().SaveScoreAndCoins();
        }
    }
}
