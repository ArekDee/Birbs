using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text coinText;
    public GameObject warningPanel;
    public GameObject warningPanel2;
    public List<GameObject> birdsToChoose;
    string tempName;
    int tempAmount;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = FindObjectOfType<SaveController>().save.coins.ToString();
        IsBirdBought();
        CurrentBird(null);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveAndReturn()
    {
        PlayerPrefs.SetString(Save.CURRENT_BIRD, FindObjectOfType<SaveController>().save.currentBird);
        PlayerPrefs.SetInt(Save.COINS, FindObjectOfType<SaveController>().save.coins);

        PlayerPrefs.SetInt(Save.COMMON_COCK, (FindObjectOfType<SaveController>().save.commonCock ? 1 : 0));
        PlayerPrefs.SetInt(Save.ROBIN, (FindObjectOfType<SaveController>().save.robin ? 1 : 0));
        PlayerPrefs.SetInt(Save.SEAGULL, (FindObjectOfType<SaveController>().save.seagull ? 1 : 0));
        PlayerPrefs.SetInt(Save.BULLFINCH, (FindObjectOfType<SaveController>().save.bullfinch ? 1 : 0));
        PlayerPrefs.SetInt(Save.JACKDAW, (FindObjectOfType<SaveController>().save.jackdaw ? 1 : 0));
        PlayerPrefs.SetInt(Save.GREATTIT, (FindObjectOfType<SaveController>().save.greattit ? 1 : 0));
        PlayerPrefs.SetInt(Save.EMPERORPENGUIN, (FindObjectOfType<SaveController>().save.emperorpenguin ? 1 : 0));
        PlayerPrefs.SetInt(Save.HOOPOE, (FindObjectOfType<SaveController>().save.hoopoe ? 1 : 0));
        PlayerPrefs.SetInt(Save.SPARROW, (FindObjectOfType<SaveController>().save.sparrow ? 1 : 0));
        PlayerPrefs.SetInt(Save.CPTNSPARROW, (FindObjectOfType<SaveController>().save.cptnsparrow ? 1 : 0));
        PlayerPrefs.SetInt(Save.STORK, (FindObjectOfType<SaveController>().save.stork ? 1 : 0));
        PlayerPrefs.SetInt(Save.FLAMINGO, (FindObjectOfType<SaveController>().save.flamingo ? 1 : 0));
        PlayerPrefs.SetInt(Save.PEACOCK, (FindObjectOfType<SaveController>().save.peacock ? 1 : 0));
        PlayerPrefs.SetInt(Save.RAVEN, (FindObjectOfType<SaveController>().save.raven ? 1 : 0));
        PlayerPrefs.SetInt(Save.DRAGON, (FindObjectOfType<SaveController>().save.dragon ? 1 : 0));
        PlayerPrefs.SetInt(Save.EAGLE, (FindObjectOfType<SaveController>().save.eagle ? 1 : 0));
        PlayerPrefs.SetInt(Save.AMONGAS, (FindObjectOfType<SaveController>().save.amongas ? 1 : 0));
        PlayerPrefs.SetInt(Save.PIGEON, (FindObjectOfType<SaveController>().save.pigeon ? 1 : 0));
        PlayerPrefs.SetInt(Save.OWL, (FindObjectOfType<SaveController>().save.owl ? 1 : 0));
        PlayerPrefs.SetInt(Save.MARSHMALLOW, (FindObjectOfType<SaveController>().save.marshmallow ? 1 : 0));
        PlayerPrefs.SetInt(Save.KIWI, (FindObjectOfType<SaveController>().save.kiwi ? 1 : 0));
        PlayerPrefs.SetInt(Save.BAT, (FindObjectOfType<SaveController>().save.bat ? 1 : 0));

        SceneManager.LoadScene("StartScene");
    }

    public void ChooseBird(string name)
    {
        if (IsBirdBought(name))
        {
            foreach (GameObject bird in birdsToChoose)
            {
                bird.transform.GetChild(0).gameObject.SetActive(false);
                bird.transform.GetChild(1).gameObject.SetActive(false);
            }
            CurrentBird(name);
            FindObjectOfType<SaveController>().save.currentBird = name;
        }
        else
        {
            tempName = name;
            tempAmount = FindBirdCost(name);
            if (FindObjectOfType<SaveController>().save.coins >= tempAmount)
            {
                warningPanel.SetActive(true);
            }
            else
            {
                warningPanel2.SetActive(true);
            }
        }
    }

    public void CurrentBird(string name)
    {
        if (name == null)
            name = FindObjectOfType<SaveController>().save.currentBird;

        if (name == "commonCock")
        {
            birdsToChoose[0].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "robin")
        {
            birdsToChoose[1].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[1].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "seagull")
        {
            birdsToChoose[2].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[2].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "bullfinch")
        {
            birdsToChoose[3].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[3].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "jackdaw")
        {
            birdsToChoose[4].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[4].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "greattit")
        {
            birdsToChoose[5].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[5].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "emperorpenguin")
        {
            birdsToChoose[6].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[6].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "hoopoe")
        {
            birdsToChoose[7].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[7].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "sparrow")
        {
            birdsToChoose[8].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[8].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "cptnsparrow")
        {
            birdsToChoose[9].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[9].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "stork")
        {
            birdsToChoose[10].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[10].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "flamingo")
        {
            birdsToChoose[11].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[11].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "peacock")
        {
            birdsToChoose[12].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[12].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "raven")
        {
            birdsToChoose[13].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[13].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "dragon")
        {
            birdsToChoose[14].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[14].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "eagle")
        {
            birdsToChoose[15].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[15].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "amongas")
        {
            birdsToChoose[16].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[16].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "pigeon")
        {
            birdsToChoose[17].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[17].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "owl")
        {
            birdsToChoose[18].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[18].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "marshmallow")
        {
            birdsToChoose[19].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[19].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "kiwi")
        {
            birdsToChoose[20].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[20].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (name == "bat")
        {
            birdsToChoose[21].transform.GetChild(0).gameObject.SetActive(true);
            birdsToChoose[21].transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public bool IsBirdBought(string name)
    {
        if (name == "commonCock" && FindObjectOfType<SaveController>().save.commonCock)
        {
            return true;
        }
        if (name == "robin" && FindObjectOfType<SaveController>().save.robin)
        {
            return true;
        }
        if (name == "seagull" && FindObjectOfType<SaveController>().save.seagull)
        {
            return true;
        }
        if (name == "bullfinch" && FindObjectOfType<SaveController>().save.bullfinch)
        {
            return true;
        }
        if (name == "jackdaw" && FindObjectOfType<SaveController>().save.jackdaw)
        {
            return true;
        }
        if (name == "greattit" && FindObjectOfType<SaveController>().save.greattit)
        {
            return true;
        }
        if (name == "emperorpenguin" && FindObjectOfType<SaveController>().save.emperorpenguin)
        {
            return true;
        }
        if (name == "hoopoe" && FindObjectOfType<SaveController>().save.hoopoe)
        {
            return true;
        }
        if (name == "sparrow" && FindObjectOfType<SaveController>().save.sparrow)
        {
            return true;
        }
        if (name == "cptnsparrow" && FindObjectOfType<SaveController>().save.cptnsparrow)
        {
            return true;
        }
        if (name == "stork" && FindObjectOfType<SaveController>().save.stork)
        {
            return true;
        }
        if (name == "flamingo" && FindObjectOfType<SaveController>().save.flamingo)
        {
            return true;
        }
        if (name == "peacock" && FindObjectOfType<SaveController>().save.peacock)
        {
            return true;
        }
        if (name == "raven" && FindObjectOfType<SaveController>().save.raven)
        {
            return true;
        }
        if (name == "dragon" && FindObjectOfType<SaveController>().save.dragon)
        {
            return true;
        }
        if (name == "eagle" && FindObjectOfType<SaveController>().save.eagle)
        {
            return true;
        }
        if (name == "amongas" && FindObjectOfType<SaveController>().save.amongas)
        {
            return true;
        }
        if (name == "pigeon" && FindObjectOfType<SaveController>().save.pigeon)
        {
            return true;
        }
        if (name == "owl" && FindObjectOfType<SaveController>().save.owl)
        {
            return true;
        }
        if (name == "marshmallow" && FindObjectOfType<SaveController>().save.marshmallow)
        {
            return true;
        }
        if (name == "kiwi" && FindObjectOfType<SaveController>().save.kiwi)
        {
            return true;
        }
        if (name == "bat" && FindObjectOfType<SaveController>().save.bat)
        {
            return true;
        }
        return false;

    }
    public int FindBirdCost(string name)
    {
        if (name == "commonCock")
        {
            return 0;
        }
        if (name == "robin")
        {
            return 50;
        }
        if (name == "seagull")
        {
            return 50;
        }
        if (name == "bullfinch")
        {
            return 100;
        }
        if (name == "jackdaw")
        {
            return 100;
        }
        if (name == "greattit")
        {
            return 100;
        }
        if (name == "emperorpenguin")
        {
            return 100;
        }
        if (name == "hoopoe")
        {
            return 150;
        }
        if (name == "sparrow")
        {
            return 150;
        }
        if (name == "cptnsparrow")
        {
            return 500;
        }
        if (name == "stork")
        {
            return 250;
        }
        if (name == "flamingo")
        {
            return 250;
        }
        if (name == "peacock")
        {
            return 300;
        }
        if (name == "raven")
        {
            return 300;
        }
        if (name == "dragon")
        {
            return 500;
        }
        if (name == "eagle")
        {
            return 500;
        }
        if (name == "amongas")
        {
            return 500;
        }
        if (name == "pigeon")
        {
            return 500;
        }
        if (name == "owl")
        {
            return 500;
        }
        if (name == "marshmallow")
        {
            return 500;
        }
        if (name == "kiwi")
        {
            return 500;
        }
        if (name == "bat")
        {
            return 500;
        }

        return 0;

    }
    public void IsBirdBought()
    {
        int birbCounter = 0;
        if (FindObjectOfType<SaveController>().save.commonCock)
        {
            birdsToChoose[0].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[0].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[0].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.robin)
        {
            birdsToChoose[1].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[1].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[1].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.seagull)
        {
            birdsToChoose[2].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[2].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[2].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.bullfinch)
        {
            birdsToChoose[3].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[3].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[3].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.jackdaw)
        {
            birdsToChoose[4].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[4].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[4].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.greattit)
        {
            birdsToChoose[5].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[5].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[5].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.emperorpenguin)
        {
            birdsToChoose[6].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[6].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[6].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.hoopoe)
        {
            birdsToChoose[7].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[7].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[7].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.sparrow)
        {
            birdsToChoose[8].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[8].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[8].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.cptnsparrow)
        {
            birdsToChoose[9].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[9].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[9].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.stork)
        {
            birdsToChoose[10].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[10].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[10].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.flamingo)
        {
            birdsToChoose[11].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[11].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[11].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.peacock)
        {
            birdsToChoose[12].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[12].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[12].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.raven)
        {
            birdsToChoose[13].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[13].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[13].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.dragon)
        {
            birdsToChoose[14].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[14].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[14].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.eagle)
        {
            birdsToChoose[15].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[15].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[15].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
            birbCounter++;
        }
        if (FindObjectOfType<SaveController>().save.amongas)
        {
            birdsToChoose[16].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[16].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[16].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (FindObjectOfType<SaveController>().save.pigeon)
        {
            birdsToChoose[17].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[17].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[17].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (FindObjectOfType<SaveController>().save.owl)
        {
            birdsToChoose[18].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[18].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[18].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (FindObjectOfType<SaveController>().save.marshmallow)
        {
            birdsToChoose[19].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[19].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[19].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (FindObjectOfType<SaveController>().save.kiwi)
        {
            birdsToChoose[20].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[20].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[20].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (FindObjectOfType<SaveController>().save.bat)
        {
            birdsToChoose[21].transform.GetChild(2).gameObject.SetActive(true);
            birdsToChoose[21].transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            birdsToChoose[21].transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (birbCounter == 16)
        {
            FindObjectOfType<PlayServices>().UnlockBirbCollectorAchievement();
        }
    }
    public void BuyBird(string name)
    {
        if (name == "commonCock")
        {
            FindObjectOfType<SaveController>().save.commonCock = true;
        }
        if (name == "robin")
        {
            FindObjectOfType<SaveController>().save.robin = true;
        }
        if (name == "seagull")
        {
            FindObjectOfType<SaveController>().save.seagull = true;
        }
        if (name == "bullfinch")
        {
            FindObjectOfType<SaveController>().save.bullfinch = true;
        }
        if (name == "jackdaw")
        {
            FindObjectOfType<SaveController>().save.jackdaw = true;
        }
        if (name == "greattit")
        {
            FindObjectOfType<SaveController>().save.greattit = true;
        }
        if (name == "emperorpenguin")
        {
            FindObjectOfType<SaveController>().save.emperorpenguin = true;
        }
        if (name == "hoopoe")
        {
            FindObjectOfType<SaveController>().save.hoopoe = true;
        }
        if (name == "sparrow")
        {
            FindObjectOfType<SaveController>().save.sparrow = true;
        }
        if (name == "cptnsparrow")
        {
            FindObjectOfType<SaveController>().save.cptnsparrow = true;
        }
        if (name == "stork")
        {
            FindObjectOfType<SaveController>().save.stork = true;
        }
        if (name == "flamingo")
        {
            FindObjectOfType<SaveController>().save.flamingo = true;
        }
        if (name == "peacock")
        {
            FindObjectOfType<SaveController>().save.peacock = true;
        }
        if (name == "raven")
        {
            FindObjectOfType<SaveController>().save.raven = true;
        }
        if (name == "dragon")
        {
            FindObjectOfType<SaveController>().save.dragon = true;
        }
        if (name == "eagle")
        {
            FindObjectOfType<SaveController>().save.eagle = true;
        }
        if (name == "amongas")
        {
            FindObjectOfType<SaveController>().save.amongas = true;
        }
        if (name == "pigeon")
        {
            FindObjectOfType<SaveController>().save.pigeon = true;
        }
        if (name == "owl")
        {
            FindObjectOfType<SaveController>().save.owl = true;
        }
        if (name == "marshmallow")
        {
            FindObjectOfType<SaveController>().save.marshmallow = true;
        }
        if (name == "kiwi")
        {
            FindObjectOfType<SaveController>().save.kiwi = true;
        }
        if (name == "bat")
        {
            FindObjectOfType<SaveController>().save.bat = true;
        }
        IsBirdBought();
    }

    public void YesBuy()
    {
        BuyBird(tempName);
        ChooseBird(tempName);
        FindObjectOfType<SaveController>().save.coins -= tempAmount;
        coinText.text = FindObjectOfType<SaveController>().save.coins.ToString();
        warningPanel.SetActive(false);
    }
    public void NoBuy()
    {
        warningPanel.SetActive(false);
    }
    public void OkNoMoney()
    {
        warningPanel2.SetActive(false);
    }
}
