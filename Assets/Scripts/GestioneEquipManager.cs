using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GestioneEquipManager : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public GameData GameData;
    public CanvasManager CanvasManager;
    public GameObject armaCorrente;
    public static GameObject armaCorrenteStatic;
    public static bool Impegnato;
    public static bool Indaffarato;

    public GameObject Pistol;
    public GameObject Gun;
    public GameObject SSG;
    public GameObject Pugni;
    public GameObject DevilBlaster;
    public GameObject WoodenKatagi;
    public GameObject FireDischarge;

    public GameObject mirinoGun;
    public GameObject mirinoPistol;
    public GameObject noMirino;
    public GameObject mirinoCorrente;
    public GameObject mirinoSSG;
    public GameObject mirinoBlaster;
    public GameObject mirinoKatagi;
    public GameObject mirinoFireDischarge;

    void Awake()
    {
        if(armaCorrenteStatic != null)
        {
            armaCorrente = armaCorrenteStatic;
        }

        PlayerManager = GameObject.Find("Protagonista").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameisPaused == false)
        {
        if(PlayerManager.Occupato == false)
        { 
        if (Impegnato == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                if (armaCorrente != Pugni)
                {
                    BracciaEquip();
                }
            }

            if(GameData.pistolUnlock == true)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.P))
                    {
                        if (armaCorrente != Pistol)
                        {
                            PistolEquip();
                        }
                    }
                }


            if (GameData.ssgUnlock == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.O))
                {
                    if (armaCorrente != SSG)
                    {
                        SSGEquip();
                    }
                }
            }

            if (GameData.gunUnlock == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Q))
                {
                    if (armaCorrente != Gun)
                    {
                        GunEquip();
                    }
                }
            }


            if (GameData.devilblasterUnlock == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.I))
                {
                    if (armaCorrente != DevilBlaster)
                    {
                        DevilBlasterEquip();
                    }
                }
            }

            if (GameData.woodenkatagiUnlock == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.X))
                {
                    if (armaCorrente != WoodenKatagi)
                    {
                        WoodenKatagiEquip();
                    }
                }
            }

            if (GameData.firedischargeUnlock == true)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (armaCorrente != FireDischarge)
                    {
                        FireDischargeEquip();
                    }
                }
            }

        }
        }
        }
    }

    public void BracciaEquip()
    {
        Indaffarato = false;
        Impegnato = false;
        
        mirinoCorrente.SetActive(false);
        mirinoCorrente = noMirino;

        armaCorrenteStatic = Pugni;
        armaCorrente.SetActive(false);
        armaCorrente = Pugni;

        CanvasManager.currentOnCanvas.SetActive(false);
        CanvasManager.currentOnCanvas = CanvasManager.canvasNullo;
        CanvasManager.currentOnCanvas.SetActive(true);

        Pugni.SetActive(true);
    }

    public void SSGEquip()
    {
        Indaffarato = true;
        mirinoCorrente.SetActive(false);
        mirinoCorrente = mirinoSSG;
        mirinoCorrente.SetActive(true);

        CanvasManager.currentOnCanvas.SetActive(false);
        CanvasManager.currentOnCanvas = CanvasManager.ssgonCanvas;
        CanvasManager.currentOnCanvas.SetActive(true);

        armaCorrenteStatic = SSG;
        armaCorrente.SetActive(false);
        armaCorrente = SSG;

        SSG.SetActive(true);
    }

    public void DevilBlasterEquip()
    {
    Indaffarato = true;
    mirinoCorrente.SetActive(false);
    mirinoCorrente = mirinoBlaster;
    mirinoCorrente.SetActive(true);

    CanvasManager.currentOnCanvas.SetActive(false);
    CanvasManager.currentOnCanvas = CanvasManager.devilblasteronCanvas;
    CanvasManager.currentOnCanvas.SetActive(true);

    armaCorrenteStatic = DevilBlaster;
    armaCorrente.SetActive(false);
    armaCorrente = DevilBlaster;
    DevilBlaster.SetActive(true);
    }

    public void WoodenKatagiEquip()
    {
        Indaffarato = true;
        mirinoCorrente.SetActive(false);
        mirinoCorrente = mirinoKatagi;
        mirinoCorrente.SetActive(true);

        CanvasManager.currentOnCanvas.SetActive(false);
        CanvasManager.currentOnCanvas = CanvasManager.canvasNullo;
        CanvasManager.currentOnCanvas.SetActive(true);

        armaCorrenteStatic = WoodenKatagi;
        armaCorrente.SetActive(false);
        armaCorrente = WoodenKatagi;
        WoodenKatagi.SetActive(true);
    }

    public void FireDischargeEquip()
    {
        Indaffarato = true;
        mirinoCorrente.SetActive(false);
        mirinoCorrente = mirinoFireDischarge;
        mirinoCorrente.SetActive(true);

        armaCorrenteStatic = FireDischarge;
        armaCorrente.SetActive(false);
        armaCorrente = FireDischarge;
        FireDischarge.SetActive(true);
    }

    public void GunEquip()
    {
        Indaffarato = true;

        mirinoCorrente.SetActive(false);
        mirinoCorrente = mirinoGun;
        mirinoCorrente.SetActive(true);

        CanvasManager.currentOnCanvas.SetActive(false);
        CanvasManager.currentOnCanvas = CanvasManager.GunOnCanvas;
        CanvasManager.currentOnCanvas.SetActive(true);

        armaCorrenteStatic = Gun;
        armaCorrente.SetActive(false);
        armaCorrente = Gun;
        Gun.SetActive(true);
    }

    public void PistolEquip()
    {
        Indaffarato = true;

        mirinoCorrente.SetActive(false);
        mirinoCorrente = mirinoPistol;
        mirinoCorrente.SetActive(true);

        CanvasManager.currentOnCanvas.SetActive(false);
        CanvasManager.currentOnCanvas = CanvasManager.pistolOnCanvas;
        CanvasManager.currentOnCanvas.SetActive(true);

        armaCorrenteStatic = Pistol;
        armaCorrente.SetActive(false);
        armaCorrente = Pistol;
        Pistol.SetActive(true);
    }
}


