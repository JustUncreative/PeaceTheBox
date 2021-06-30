using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckCheck : MonoBehaviour
{
    private float stuckTimer;
    public bool _isStuck;
    [SerializeField] private float checkRadius;
    [SerializeField] private Transform stuckCheck;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float _stuckTime = 1.5f;
    private void Start() {
        stuckTimer = _stuckTime;
    }
    private void Update()
    {
        checkRadius = 0.9f * Movement.instance.transform.localScale.x/2;

        if(IsStuck() && PlayerHealthController.instance._isAlive){
            stuckTimer -= Time.deltaTime;

            if(stuckTimer < 0){
                PlayerHealthController.instance.currentHealth = 0f;
                print("You are alive - " + PlayerHealthController.instance._isAlive);
                stuckTimer = _stuckTime;
            }
        }
    }

    private bool IsStuck(){
        return Physics2D.OverlapCircle(stuckCheck.position, checkRadius, Layer);
    }
}
