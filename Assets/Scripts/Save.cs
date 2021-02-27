using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public static string BEST_SCORE = "bestScore";
    public static string CURRENT_BIRD = "currentBird";
    public static string COINS = "coins";

    public static string COMMON_COCK = "commonCock";
    public static string ROBIN = "robin";
    public static string SEAGULL = "seagull";
    public static string BULLFINCH = "bullfinch";
    public static string JACKDAW = "jackdaw";
    public static string GREATTIT = "greattit";
    public static string EMPERORPENGUIN = "emperorpenguin";
    public static string HOOPOE = "hoopoe";
    public static string SPARROW = "sparrow";
    public static string CPTNSPARROW = "cptnsparrow";
    public static string STORK = "stork";
    public static string FLAMINGO = "flamingo";
    public static string PEACOCK = "peacock";
    public static string RAVEN = "raven";
    public static string DRAGON = "dragon";
    public static string EAGLE = "eagle";
    public static string AMONGAS = "amongas";
    public static string PIGEON = "pigeon";
    public static string OWL = "owl";
    public static string MARSHMALLOW = "marshmallow";
    public static string KIWI = "kiwi";
    public static string BAT = "bat";

    public static string FIRST_GAME = "firstgame";
    public static string ORNITHOLOGIST_AND_EXPERT = "ornithologistExpert";
    public static string REACH_THE_MOON = "reachTheMoon";
    public static string SKY_IS_NOT_THE_LIMIT = "skyIsNotTheLimit";
    public static string ONE_GIANT_STEP = "oneGiantStep";
    public static string BIRB_COLLECTOR = "birbCollector";
    public static string NEVER_GIVE_UP = "neverGiveUp";
    public static string SECOND_CHANCE = "secondChance";
    public static string RISK_TAKER = "riskTaker";

    public int bestScore;
    public string currentBird;
    public int coins;

    public bool commonCock = true;
    public bool robin = false;
    public bool seagull = false;
    public bool bullfinch = false;
    public bool jackdaw = false;
    public bool greattit = false;
    public bool emperorpenguin = false;
    public bool hoopoe = false;
    public bool sparrow = false;
    public bool cptnsparrow = false;
    public bool stork = false;
    public bool flamingo = false;
    public bool peacock = false;
    public bool raven = false;
    public bool dragon = false;
    public bool eagle = false;
    public bool amongas = false;
    public bool pigeon = false;
    public bool owl = false;
    public bool marshmallow = false;
    public bool kiwi = false;
    public bool bat = false;

    //achievements
    public bool firstgame = false;
    public int ornithologistExpert = 0;
    public bool reachTheMoon = false;
    public bool skyIsNotTheLimit = false;
    public bool oneGiantStep = false;
    public bool birbCollector = false;
    public int neverGiveUp = 0;
    public int secondChance = 0;
    public int riskTaker = 0;
}
