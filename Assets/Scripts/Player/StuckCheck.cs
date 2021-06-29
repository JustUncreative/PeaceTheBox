using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckCheck : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private Transform stuckCheck;
    [SerializeField] private LayerMask Layer;
    void Update()
    {
        checkRadius = 0.9f * Movement.instance.transform.localScale.x/2;

        if(isStuck()){
            print("You died");
        }
    }

    private bool isStuck(){
        return Physics2D.OverlapCircle(stuckCheck.position, checkRadius, Layer);
    }
}
