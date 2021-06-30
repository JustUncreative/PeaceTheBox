using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearDamage : MonoBehaviour
{
    private bool _canDamage = true;
    private float _damageTimer;
    [SerializeField] private float _damageTime;
    private void Start() {
        _damageTimer = _damageTime;
    }
    private void Update() {
        
        print(_damageTimer);  
    }
    public void ApplySmearDamage(TileData data){
        if(data != null && data.canSmear && data.canDamage){
            PlayerHealthController.instance.ReduceHealthPoints(data.damage);
        }
    }

    public void ApplyDamage(TileData data){
        if(data != null && data.canDamage && !data.canSmear){
            _damageTimer -= Time.deltaTime;

            if(_canDamage){
                PlayerHealthController.instance.ReduceHealthPoints(data.damage);
                _canDamage = false;
            }
        }else{
            _damageTimer = _damageTime;

            _canDamage = true;
        }
        if(_damageTimer < 0){
            PlayerHealthController.instance.ReduceHealthPoints(data.damage);

            _damageTimer = _damageTime;

            _canDamage = true;
        }
    }
}
