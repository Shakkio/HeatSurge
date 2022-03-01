using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameVariables
{
    public bool ssgUnlock = false;
    public bool woodenkatagiUnlock = false;
    public bool devilblasterUnlock = false;
    public bool firedischargeUnlock = false;
    public bool devilblasterRepaired = false;
    public bool gunUnlock = false;


    public int gunAmmo = 0;
    public int devilblasterAmmo = 0;
    public int firedischargeAmmo = 0;

    public float playerpositionX;
    public float playerpositionY;
    public int saveroomValue = 0;

    public bool Map001unlock = false;
    public bool flag1 = false;
    public bool flag2 = false;
    public bool flag3 = false;
    public bool flag4 = false;
    public bool flag5 = false;
    public bool flag6 = false;
    public bool flag7 = false;
    public bool flag8 = false;
    public bool flag9 = false;
    public bool flag10 = false;
    public bool flag11 = false;
    public bool flag12 = false;
    public bool flag13 = false;
    public bool flag14 = false;
    public bool flag15 = false;
    public bool flag16 = false;
    public bool flag17 = false;
    public bool flag18 = false;
    public bool flag19 = false;
    public bool flag20 = false;
    public bool flag21 = false;
    public bool flag22 = false;
    public bool flag23 = false;
    public bool flag24 = false;
    public bool flag25 = false;
    public bool flag26 = false;
    public bool flag27 = false;
    public bool flag28 = false;
}



public class GameData : MonoBehaviour
{
    string dataPath;

    public static bool ssgUnlock = true;
    public static bool woodenkatagiUnlock = false;
    public static bool devilblasterUnlock = true;
    public static bool firedischargeUnlock = false;
    public static bool devilblasterRepaired = false;
    public static bool gunUnlock = true;
    public static bool pistolUnlock = false;
    public static bool Cassetta = false;

    public static int gunAmmo = 50;
    public static int devilblasterAmmo = 40;
    public static int firedischargeAmmo = 0;

    public static Vector2 playerTeleport = Vector2.zero;
    public static Vector2 playerPosition;
    public static int saveroomValue = 0;

    public static bool ApBossDefeated = false;
    public static bool KeyAp = false;

    //Map001
    public static bool Map001unlock = false;
    public static bool flag1 = false;
    public static bool flag2 = false;
    public static bool flag3 = false;
    public static bool flag4 = false;
    public static bool flag5 = false;
    public static bool flag6 = false;

    //Map002
    public static bool flag7 = false;
    public static bool flag8 = false;

    //Map003
    public static bool flag9 = false;

    //Map004
    public static bool flag10 = false;
    public static bool flag11 = false;
    public static bool flag12 = false;

    //Map005
    public static bool flag13 = false;
    public static bool flag14 = false;
    public static bool flag15 = false;
    public static bool flag16 = false;
    public static bool flag17 = false;
    public static bool flag18 = false;
    public static bool flag19 = false;
    public static bool flag20 = false;
    public static bool flag21 = false;

    //Map006
    public static bool flag22 = false;
    public static bool flag23 = false;
    public static bool flag24 = false;
    public static bool flag25 = false;

    //Map007
    public static bool flag26 = false;
    public static bool flag27 = false;

    //Map008
    public static bool flag28 = false;



    // Update is called once per frame

    private void Awake()
    {
        dataPath = Application.dataPath + "/saveFile.wad";
    }

    public void Save()
    {
        Debug.Log(dataPath);
        FileStream file;
        if(File.Exists(dataPath))
        {
            file = File.OpenWrite(dataPath);
        }
        else
        {
            file = File.Create(dataPath);
        }

        GameVariables variables = new GameVariables();

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        variables.ssgUnlock = ssgUnlock;
        variables.woodenkatagiUnlock = woodenkatagiUnlock;
        variables.devilblasterUnlock = devilblasterUnlock;
        variables.firedischargeUnlock = firedischargeUnlock;
        variables.gunUnlock = gunUnlock;

        variables.gunAmmo = gunAmmo;
        variables.devilblasterAmmo = devilblasterAmmo;
        variables.firedischargeAmmo = firedischargeAmmo;

        variables.playerpositionX = playerPosition.x;
        variables.playerpositionY = playerPosition.y;
        variables.saveroomValue = saveroomValue;

        variables.Map001unlock = Map001unlock;

        variables.flag1 = flag1;
        variables.flag2 = flag2;
        variables.flag3 = flag3;
        variables.flag4 = flag4;
        variables.flag5 = flag5;
        variables.flag6 = flag6;
        variables.flag7 = flag7;
        variables.flag8 = flag8;
        variables.flag9 = flag9;
        variables.flag10 = flag10;
        variables.flag11 = flag11;
        variables.flag12 = flag12;
        variables.flag13 = flag13;
        variables.flag14 = flag14;
        variables.flag15 = flag15;
        variables.flag16 = flag16;
        variables.flag17 = flag17;
        variables.flag18 = flag18;
        variables.flag19 = flag19;
        variables.flag20 = flag20;
        variables.flag21 = flag21;
        variables.flag22 = flag22;
        variables.flag23 = flag23;
        variables.flag24 = flag24;
        variables.flag25 = flag25;
        variables.flag26 = flag26;
        variables.flag27 = flag27;
        variables.flag28 = flag28;

        binaryFormatter.Serialize(file, variables);
        file.Close();
    }

    public void Load()
    {
        FileStream file;
        dataPath = Application.dataPath + "/saveFile.wad";
        if (File.Exists(dataPath))
        {
            file = File.OpenRead(dataPath);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            GameVariables gameVariables;

            gameVariables = (GameVariables)binaryFormatter.Deserialize(file);
            file.Close();

            ssgUnlock = gameVariables.ssgUnlock;
            woodenkatagiUnlock = gameVariables.woodenkatagiUnlock;
            devilblasterUnlock = gameVariables.devilblasterUnlock;
            firedischargeUnlock = gameVariables.firedischargeUnlock;
            gunUnlock = gameVariables.gunUnlock;

            gunAmmo = gameVariables.gunAmmo;
            devilblasterAmmo = gameVariables.devilblasterAmmo;
            firedischargeAmmo = gameVariables.firedischargeAmmo;

            playerPosition.x = gameVariables.playerpositionX;
            playerPosition.y = gameVariables.playerpositionY;
            saveroomValue = gameVariables.saveroomValue;

            Map001unlock = gameVariables.Map001unlock;

            flag1 = gameVariables.flag1;
            flag2 = gameVariables.flag2;
            flag3 = gameVariables.flag3;
            flag4 = gameVariables.flag4;
            flag5 = gameVariables.flag5;
            flag6 = gameVariables.flag6;
            flag7 = gameVariables.flag7;
            flag8 = gameVariables.flag8;
            flag9 = gameVariables.flag9;
            flag10 = gameVariables.flag10;
            flag11 = gameVariables.flag11;
            flag12 = gameVariables.flag12;
            flag13 = gameVariables.flag13;
            flag14 = gameVariables.flag14;
            flag15 = gameVariables.flag15;
            flag16 = gameVariables.flag16;
            flag17 = gameVariables.flag17;
            flag18 = gameVariables.flag18;
            flag19 = gameVariables.flag19;
            flag20 = gameVariables.flag20;
            flag21 = gameVariables.flag21;
            flag22 = gameVariables.flag22;
            flag23 = gameVariables.flag23;
            flag24 = gameVariables.flag24;
            flag25 = gameVariables.flag25;
            flag26 = gameVariables.flag26;
            flag27 = gameVariables.flag27;
            flag28 = gameVariables.flag28;

            playerTeleport = new Vector2(playerPosition.x, playerPosition.y);
            SceneManager.LoadScene("SaveRoom");
        }
        else
        {
            Debug.Log("sque");
        }

    }
}
