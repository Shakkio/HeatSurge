using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    string dataPath;
    bool m_gameisPaused = false;
    public GameData GameData;

    private void Awake()
    {
        dataPath = Application.dataPath + "/saveFile.wad";
    }

    void Update()
    {
        
    }

    public void MainMenu()
    {
        m_gameisPaused = false;
        GameObject.Find("Protagonista").GetComponent<PlayerManager>().PauseGame(m_gameisPaused);
        Debug.Log("LoadSceneMainMenu");
        SceneManager.LoadScene("Map000");
    }

    public void Resume()
    {
        m_gameisPaused = false;
        GameObject.Find("Protagonista").GetComponent<PlayerManager>().PauseGame(m_gameisPaused);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }   
    
    public void MenuLoad()
    {
        m_gameisPaused = false;
        GameData.Load();
    }
}
