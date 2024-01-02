using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{   
    
    public  List<TileDataSet> tileDataSet;
    public DynamicAudio.MaterialType type;
}
[System.Serializable]
public struct TileDataSet
{
    public TileBase tile;
    public bool canBeDestory;
   
}