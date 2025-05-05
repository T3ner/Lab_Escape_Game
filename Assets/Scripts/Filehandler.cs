using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Filehandler
{
    private string dirPath = "";
    private string fileName = "";

    public Filehandler(string dirPath, string fileName)
    {
        this.dirPath = dirPath;
        this.fileName = fileName;
    }

    public Gamedata Load()
    {
        string fullpath = Path.Combine(dirPath, fileName);
        Gamedata loadedData = null;

        if (File.Exists(fullpath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<Gamedata>(dataToLoad);
            }catch (Exception e)
            {
                Debug.LogError("Error occured when loading data at "+fullpath+e);
            }
        }
        return loadedData;
    }

    public void Save(Gamedata gd)
    {
        string fullpath = Path.Combine(dirPath, fileName);
        
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            string dataToSave = JsonUtility.ToJson(gd, true);
            using (FileStream stream = new FileStream(fullpath, FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSave);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when Saving data at " + fullpath + e);
        }
        
    }
}
