using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private static SaveController _instance;

    public static SaveController Instance
    {
        get { return _instance; }
    }
    public Save save;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartSaves()
    {
        //DeleteSaveGame("save");
        if (save.currentBird == "")
        {
            if (!PlayerPrefs.HasKey("changeSaves"))
            {
                PlayerPrefs.SetInt("changeSaves", 0);
            }
            if (PlayerPrefs.GetInt("changeSaves") == 0 && DoesSaveGameExist("save"))
            {
                save = LoadGame("save");
                MakePlayerPrefsFromSave();
                DeleteSaveGame("save");
                PlayerPrefs.SetInt("changeSaves", 1);
            }
            else
            {
                if (!PlayerPrefs.HasKey(Save.CURRENT_BIRD))
                {
                    CreateNewPrefabs();
                }
                MakeSave();
            }
        }
    }

    public void MakePlayerPrefsFromSave()
    {
        PlayerPrefs.SetString(Save.CURRENT_BIRD, save.currentBird);
        PlayerPrefs.SetInt(Save.BEST_SCORE, save.bestScore);
        PlayerPrefs.SetInt(Save.COINS, save.coins);

        PlayerPrefs.SetInt(Save.COMMON_COCK, (save.commonCock ? 1 : 0));
        PlayerPrefs.SetInt(Save.ROBIN, (save.robin ? 1 : 0));
        PlayerPrefs.SetInt(Save.SEAGULL, (save.seagull ? 1 : 0));
        PlayerPrefs.SetInt(Save.BULLFINCH, (save.bullfinch ? 1 : 0));
        PlayerPrefs.SetInt(Save.JACKDAW, (save.jackdaw ? 1 : 0));
        PlayerPrefs.SetInt(Save.GREATTIT, (save.greattit ? 1 : 0));
        PlayerPrefs.SetInt(Save.EMPERORPENGUIN, (save.emperorpenguin ? 1 : 0));
        PlayerPrefs.SetInt(Save.HOOPOE, (save.hoopoe ? 1 : 0));
        PlayerPrefs.SetInt(Save.SPARROW, (save.sparrow ? 1 : 0));
        PlayerPrefs.SetInt(Save.CPTNSPARROW, (save.cptnsparrow ? 1 : 0));
        PlayerPrefs.SetInt(Save.STORK, (save.stork ? 1 : 0));
        PlayerPrefs.SetInt(Save.FLAMINGO, (save.flamingo ? 1 : 0));
        PlayerPrefs.SetInt(Save.PEACOCK, (save.peacock ? 1 : 0));
        PlayerPrefs.SetInt(Save.RAVEN, (save.raven ? 1 : 0));
        PlayerPrefs.SetInt(Save.DRAGON, (save.dragon ? 1 : 0));
        PlayerPrefs.SetInt(Save.EAGLE, (save.eagle ? 1 : 0));
        PlayerPrefs.SetInt(Save.AMONGAS, (save.amongas ? 1 : 0));
        PlayerPrefs.SetInt(Save.PIGEON, (save.pigeon ? 1 : 0));
        PlayerPrefs.SetInt(Save.OWL, (save.owl ? 1 : 0));
        PlayerPrefs.SetInt(Save.MARSHMALLOW, (save.marshmallow ? 1 : 0));
        PlayerPrefs.SetInt(Save.KIWI, (save.kiwi ? 1 : 0));
        PlayerPrefs.SetInt(Save.BAT, (save.bat ? 1 : 0));

        PlayerPrefs.SetInt(Save.FIRST_GAME, (save.firstgame ? 1 : 0));
        PlayerPrefs.SetInt(Save.ORNITHOLOGIST_AND_EXPERT, save.ornithologistExpert);
        PlayerPrefs.SetInt(Save.REACH_THE_MOON, (save.reachTheMoon ? 1 : 0));
        PlayerPrefs.SetInt(Save.SKY_IS_NOT_THE_LIMIT, (save.skyIsNotTheLimit ? 1 : 0));
        PlayerPrefs.SetInt(Save.ONE_GIANT_STEP, (save.oneGiantStep ? 1 : 0));
        PlayerPrefs.SetInt(Save.BIRB_COLLECTOR, (save.birbCollector ? 1 : 0));
        PlayerPrefs.SetInt(Save.NEVER_GIVE_UP, save.neverGiveUp);
        PlayerPrefs.SetInt(Save.SECOND_CHANCE, save.secondChance);
        PlayerPrefs.SetInt(Save.RISK_TAKER, save.riskTaker);
    }
    public void CreateNewPrefabs()
    {
        PlayerPrefs.SetString(Save.CURRENT_BIRD, "commonCock");
        PlayerPrefs.SetInt(Save.BEST_SCORE, 0);
        PlayerPrefs.SetInt(Save.COINS, 0);

        PlayerPrefs.SetInt(Save.COMMON_COCK, 1);
        PlayerPrefs.SetInt(Save.ROBIN, 0);
        PlayerPrefs.SetInt(Save.SEAGULL, 0);
        PlayerPrefs.SetInt(Save.BULLFINCH, 0);
        PlayerPrefs.SetInt(Save.JACKDAW, 0);
        PlayerPrefs.SetInt(Save.GREATTIT, 0);
        PlayerPrefs.SetInt(Save.EMPERORPENGUIN, 0);
        PlayerPrefs.SetInt(Save.HOOPOE, 0);
        PlayerPrefs.SetInt(Save.SPARROW, 0);
        PlayerPrefs.SetInt(Save.CPTNSPARROW, 0);
        PlayerPrefs.SetInt(Save.STORK, 0);
        PlayerPrefs.SetInt(Save.FLAMINGO, 0);
        PlayerPrefs.SetInt(Save.PEACOCK, 0);
        PlayerPrefs.SetInt(Save.RAVEN, 0);
        PlayerPrefs.SetInt(Save.DRAGON, 0);
        PlayerPrefs.SetInt(Save.EAGLE, 0);
        PlayerPrefs.SetInt(Save.AMONGAS, 0);
        PlayerPrefs.SetInt(Save.PIGEON, 0);
        PlayerPrefs.SetInt(Save.OWL, 0);
        PlayerPrefs.SetInt(Save.MARSHMALLOW, 0);
        PlayerPrefs.SetInt(Save.KIWI, 0);
        PlayerPrefs.SetInt(Save.BAT, 0);

        PlayerPrefs.SetInt(Save.FIRST_GAME, 0);
        PlayerPrefs.SetInt(Save.ORNITHOLOGIST_AND_EXPERT, 0);
        PlayerPrefs.SetInt(Save.REACH_THE_MOON, 0);
        PlayerPrefs.SetInt(Save.SKY_IS_NOT_THE_LIMIT, 0);
        PlayerPrefs.SetInt(Save.ONE_GIANT_STEP, 0);
        PlayerPrefs.SetInt(Save.BIRB_COLLECTOR, 0);
        PlayerPrefs.SetInt(Save.NEVER_GIVE_UP, 0);
        PlayerPrefs.SetInt(Save.SECOND_CHANCE, 0);
        PlayerPrefs.SetInt(Save.RISK_TAKER, 0);
    }
    public void MakeSave()
    {
        save = new Save();
        save.currentBird = PlayerPrefs.GetString(Save.CURRENT_BIRD, "commonCock");
        save.bestScore = PlayerPrefs.GetInt(Save.BEST_SCORE, 0);
        save.coins = PlayerPrefs.GetInt(Save.COINS, 0);

        save.commonCock = Convert.ToBoolean(PlayerPrefs.GetInt(Save.COMMON_COCK, 1));
        save.robin = Convert.ToBoolean(PlayerPrefs.GetInt(Save.ROBIN, 0));
        save.seagull = Convert.ToBoolean(PlayerPrefs.GetInt(Save.SEAGULL, 0));
        save.bullfinch = Convert.ToBoolean(PlayerPrefs.GetInt(Save.BULLFINCH, 0));
        save.jackdaw = Convert.ToBoolean(PlayerPrefs.GetInt(Save.JACKDAW, 0));
        save.greattit = Convert.ToBoolean(PlayerPrefs.GetInt(Save.GREATTIT, 0));
        save.emperorpenguin = Convert.ToBoolean(PlayerPrefs.GetInt(Save.EMPERORPENGUIN, 0));
        save.hoopoe = Convert.ToBoolean(PlayerPrefs.GetInt(Save.HOOPOE, 0));
        save.sparrow = Convert.ToBoolean(PlayerPrefs.GetInt(Save.SPARROW, 0));
        save.cptnsparrow = Convert.ToBoolean(PlayerPrefs.GetInt(Save.CPTNSPARROW, 0));
        save.stork = Convert.ToBoolean(PlayerPrefs.GetInt(Save.STORK, 0));
        save.flamingo = Convert.ToBoolean(PlayerPrefs.GetInt(Save.FLAMINGO, 0));
        save.peacock = Convert.ToBoolean(PlayerPrefs.GetInt(Save.PEACOCK, 0));
        save.raven = Convert.ToBoolean(PlayerPrefs.GetInt(Save.RAVEN, 0));
        save.dragon = Convert.ToBoolean(PlayerPrefs.GetInt(Save.DRAGON, 0));
        save.eagle = Convert.ToBoolean(PlayerPrefs.GetInt(Save.EAGLE, 0));
        save.amongas = Convert.ToBoolean(PlayerPrefs.GetInt(Save.AMONGAS, 0));
        save.pigeon = Convert.ToBoolean(PlayerPrefs.GetInt(Save.PIGEON, 0));
        save.owl = Convert.ToBoolean(PlayerPrefs.GetInt(Save.OWL, 0));
        save.marshmallow = Convert.ToBoolean(PlayerPrefs.GetInt(Save.MARSHMALLOW, 0));
        save.kiwi = Convert.ToBoolean(PlayerPrefs.GetInt(Save.KIWI, 0));
        save.bat = Convert.ToBoolean(PlayerPrefs.GetInt(Save.BAT, 0));

        save.firstgame = Convert.ToBoolean(PlayerPrefs.GetInt(Save.FIRST_GAME, 0));
        save.ornithologistExpert = PlayerPrefs.GetInt(Save.ORNITHOLOGIST_AND_EXPERT, 0);
        save.reachTheMoon = Convert.ToBoolean(PlayerPrefs.GetInt(Save.REACH_THE_MOON, 0));
        save.skyIsNotTheLimit = Convert.ToBoolean(PlayerPrefs.GetInt(Save.SKY_IS_NOT_THE_LIMIT, 0));
        save.oneGiantStep = Convert.ToBoolean(PlayerPrefs.GetInt(Save.ONE_GIANT_STEP, 0));
        save.birbCollector = Convert.ToBoolean(PlayerPrefs.GetInt(Save.BIRB_COLLECTOR, 0));
        save.neverGiveUp = PlayerPrefs.GetInt(Save.NEVER_GIVE_UP, 0);
        save.secondChance = PlayerPrefs.GetInt(Save.SECOND_CHANCE, 0);
        save.riskTaker = PlayerPrefs.GetInt(Save.RISK_TAKER, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public static bool SaveGame(Save saveGame, string name)
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GetSavePath(name), FileMode.Create);
            formatter.Serialize(stream, saveGame);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public static Save LoadGame(string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetSavePath(name), FileMode.Open);
        return formatter.Deserialize(stream) as Save;
    }

    public static bool DeleteSaveGame(string name)
    {
        try
        {
            File.Delete(GetSavePath(name));
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public static bool DoesSaveGameExist(string name)
    {
        return File.Exists(GetSavePath(name));
    }
    private static string GetSavePath(string name)
    {
        return Path.Combine(Application.persistentDataPath, name + ".sav");
    }
}
