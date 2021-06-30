using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckCheck : MonoBehaviour
{
    public static StuckCheck instance;
    private float stuckTimer;
    public bool _isStuck;
    [SerializeField] private float checkRadius;
    [SerializeField] private Transform stuckCheck;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float _stuckTime = 0f;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        stuckTimer = _stuckTime;
    }
    private void Update()
    {
        checkRadius = 0.9f * Movement.instance.transform.localScale.x/2;

        if(IsStuck() && !_isStuck){
            stuckTimer -= Time.deltaTime;

            if(stuckTimer <= 0){
                _isStuck = true;
                stuckTimer = _stuckTime;
            }
        }
    }
    private void FixedUpdate() {
        if(IsStuck() && _isStuck){
            PlayerHealthController.instance.currentHealth -= 0.25f;
            
            PlayerHealthController.instance.DetectPhase();
            PlayerHealthController.instance.ChangePhase();
        }

        if(!IsStuck() && _isStuck){
            _isStuck = false;
            PlayerHealthController.instance.currentHealth = Mathf.Floor(PlayerHealthController.instance.currentHealth);
        }
    }

    private bool IsStuck(){
        return Physics2D.OverlapCircle(stuckCheck.position, checkRadius, Layer);
    }
}
