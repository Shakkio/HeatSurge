using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public GameObject Player;
    bool CssgUnlock = true;
    bool CwoodenkatagiUnlock = false;
    bool CdevilblasterUnlock = false;
    bool CfiredischargeUnlock = false;
    bool CdevilblasterRepaired = false;
    bool CgunUnlock = true;

    int CgunAmmo = 25;
    int CdevilblasterAmmo = 0;
    int CfiredischargeAmmo = 0;

    bool Cflag1 = false;
    bool Cflag2 = false;
    bool Cflag3 = false;
    bool Cflag4 = false;
    bool Cflag5 = false;
    bool Cflag6 = false;
    bool Cflag7 = false;
    bool Cflag8 = false;
    bool Cflag9 = false;
    bool Cflag10 = false;
    bool Cflag11 = false;
    bool Cflag12 = false;
    bool Cflag13 = false;
    bool Cflag14 = false;
    bool Cflag15 = false;

    void Start()
    {
        
    }

    private void Awake()
    {
        CheckPoint();
        if (GameData.playerTeleport != Vector2.zero)
        {
            Player.transform.position = GameData.playerTeleport;
        }
    }

    void Update()
    {
        
    }

    public void CheckPoint()
    {
        CssgUnlock = GameData.ssgUnlock;
        CwoodenkatagiUnlock = GameData.woodenkatagiUnlock;
        CdevilblasterUnlock = GameData.devilblasterUnlock;
        CdevilblasterRepaired = GameData.devilblasterRepaired;
        CfiredischargeUnlock = GameData.firedischargeUnlock;
        CgunUnlock = GameData.gunUnlock;

        CgunAmmo = GameData.gunAmmo;
        CdevilblasterAmmo = GameData.devilblasterAmmo;
        CfiredischargeAmmo = GameData.firedischargeAmmo;

        Cflag1 = GameData.flag1;
        Cflag2 = GameData.flag2;
        Cflag3 = GameData.flag3;
        Cflag4 = GameData.flag4;
        Cflag5 = GameData.flag5;
        Cflag6 = GameData.flag6;
        Cflag7 = GameData.flag7;
        Cflag8 = GameData.flag8;
        Cflag9 = GameData.flag9;
        Cflag10 = GameData.flag10;
        Cflag11 = GameData.flag11;
        Cflag12 = GameData.flag12;
        Cflag13 = GameData.flag13;
        Cflag14 = GameData.flag14;
        Cflag15 = GameData.flag15;
    }

    public void GetData()
    {
        GameData.ssgUnlock = CssgUnlock;
        GameData.woodenkatagiUnlock = CwoodenkatagiUnlock;
        GameData.devilblasterUnlock = CdevilblasterUnlock;
        GameData.devilblasterRepaired = CdevilblasterRepaired;
        GameData.firedischargeUnlock = CfiredischargeUnlock;
        GameData.gunUnlock = CgunUnlock;

        GameData.gunAmmo = CgunAmmo;
        GameData.devilblasterAmmo = CdevilblasterAmmo;
        GameData.firedischargeAmmo = CfiredischargeAmmo;

        GameData.flag1 = Cflag1;
        GameData.flag2 = Cflag2;
        GameData.flag3 = Cflag3;
        GameData.flag4 = Cflag4;
        GameData.flag5 = Cflag5;
        GameData.flag6 = Cflag6;
        GameData.flag7 = Cflag7;
        GameData.flag8 = Cflag8;
        GameData.flag9 = Cflag9;
        GameData.flag10 = Cflag10;
        GameData.flag11 = Cflag11;
        GameData.flag12 = Cflag12;
        GameData.flag13 = Cflag13;
        GameData.flag14 = Cflag14;
        GameData.flag15 = Cflag15;
    }
}
