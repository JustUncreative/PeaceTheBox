using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float currentHealth;
    public static PlayerHealthController instance;
    [SerializeField] public float maxHealth;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ReduceHealthPoints(float Points){
        if(isAlive()){
            currentHealth -= Points;
        }
    }
    public void AddHealthPoints(float Points){
        if(isAlive() && currentHealth < maxHealth){
            currentHealth += Points;
        }
        editCurrentHealth();
    }
    public bool isAlive(){
        if(currentHealth > 0){
            return true;
        }
        else{
            return false;
        }
    }
    public void editCurrentHealth(){
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
}
