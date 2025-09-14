using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Isave
{
    void Savedata(ref Gamedata gd); 
    void Loaddata(Gamedata gd);
}