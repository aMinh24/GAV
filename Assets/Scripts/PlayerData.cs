using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string Name;
    public string Level;
    public int Gold;

}
[Serializable]
public class ListPlayer
{
    public PlayerData[] PlayerDatas;
}
