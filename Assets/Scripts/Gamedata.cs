using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class Gamedata
{
    public Vector3 playerPos;
    public SerializedDictionary<string, Vector3> phyobj;
    public Gamedata()
    {
        playerPos = new Vector3();
        phyobj = new SerializedDictionary<string, Vector3>();
    }
}