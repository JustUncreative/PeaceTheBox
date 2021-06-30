using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearDamage : MonoBehaviour
{
    private float _damageTimer;
    [SerializeField] private float _damageTime;
    private void Start() {
        _damageTimer = _damageTime;
    }
    public void ApplySmearDamage(TileData data){
        if(data != null && data.canSmear && data.canDamage){
            PlayerHealthController.instance.ReduceHealthPoints(data.damage);
        }
    }

    public void ApplyDamage(TileData data){
        if(data != null && data.canDamage && !data.canSmear){
            _damageTimer -= Time.deltaTime;
        }

        if(_damageTimer < 0){
            PlayerHealthController.instance.ReduceHealthPoints(data.damage);

            _damageTimer = _damageTime;
        }
    }
}
