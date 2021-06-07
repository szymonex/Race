using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Map", menuName = "Map")]
public class Map : ScriptableObject
{
    public string mapName;
    public Sprite thumbnail;
    public string mapFileName;
}
