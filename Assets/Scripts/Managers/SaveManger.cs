using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManger : MonoBehaviour
{
    [SerializeField]
    private string filename;

    private List<Isave> IsaveList;
    private Filehandler fileHandler;

    Gamedata gamedata;
    public static SaveManger instance { get; private set; }
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.fileHandler = new Filehandler(Application.persistentDataPath, filename);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }

    private void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.IsaveList = FindSaveObj();
        LoadGame();
    }
    
    public void NewGame()
    {
        this.gamedata = new Gamedata();
    }

    public void SaveGame()
    {
        if (this.gamedata == null) {
            return; 
        }

        foreach (Isave save in IsaveList)
        {
            save.Savedata(ref gamedata);
        }
        fileHandler.Save(gamedata);
    }

    public void LoadGame()
    {
        this.fileHandler.Load();
        if (this.gamedata == null) 
        {
            this.gamedata = new Gamedata();
            return;
        }

        foreach (Isave save in IsaveList)
        {
            save.Loaddata(gamedata);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<Isave> FindSaveObj()
    {
        IEnumerable<Isave> saveObj = FindObjectsOfType<MonoBehaviour>().OfType<Isave>();

        return new List<Isave>(saveObj);
    }
}