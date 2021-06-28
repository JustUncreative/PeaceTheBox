using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTilemap : MonoBehaviour
{
    public static groundTilemap instance;
    private void Awake() {
        instance = this;
    }
    public Transform groundTilemapPosition;
}
