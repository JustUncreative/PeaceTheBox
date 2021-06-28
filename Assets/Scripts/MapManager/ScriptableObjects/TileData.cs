using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TIleData : ScriptableObject
{
    public TileBase[] tiles;

    public bool canSmear;

    public bool canDamage;
}
