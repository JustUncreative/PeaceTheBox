using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealthController : MonoBehaviour
{
    private bool isIncreaseHealth;
    private int[] Phase = {1, 2, 3, 4, 5, 6};
    public float currentHealth;
    private float _changePhaseTime;
    private float _increaseHealthTime;
    public static PlayerHealthController instance;
    [SerializeField] public float maxHealth;
    [SerializeField] private float increaseHealth;
    [SerializeField] private int currentPhase;
    [SerializeField] private bool isChangePhase;
    [SerializeField] private float changePhaseTime = 1f;
    [SerializeField] private float increaseHealthTime = 1f;
    [SerializeField] private float[] phaseSpeed = {30, 20, 15, 10, 5, 1};
    [SerializeField] private float[] phaseJumpPower = {4000, 3000, 2000, 1500, 1000, 500};
    [SerializeField] private float[] phaseScale = {0.2f, 0.4f, 0.6f, 1f, 2f, 3f};
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        _changePhaseTime = changePhaseTime;
        _increaseHealthTime = increaseHealthTime;

        DetectPhase();
        ChangePhase();
    }

    void Update()
    {
        if(isChangePhase){
            _changePhaseTime -= Time.deltaTime;

            //animation

            if(_changePhaseTime < 0){
                DetectPhase();

                isChangePhase = false;
                _changePhaseTime = changePhaseTime;

                ChangePhase();
            }

        }

        if(isIncreaseHealth){
            _increaseHealthTime -= Time.deltaTime;

            if(_increaseHealthTime < 0){

                _increaseHealthTime = increaseHealthTime;

                ReduceHealthPoints(increaseHealth);

                isChangePhase = true;
            }
        }
    }

    public void ReduceHealthPoints(float Points){
        if(isAlive()){
            currentHealth -= Points;
        }

            DetectPhase();
    }
    public void AddHealthPoints(float Points){
        if(isAlive() && currentHealth < maxHealth){
            currentHealth += Points;
        }

        editCurrentHealth();

        DetectPhase();
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
    public void DetectPhase(){
        if(currentHealth == 1f && currentPhase != Phase[0]){
            currentPhase = Phase[0];
        }
        else if(currentHealth > 1 && currentHealth < 25 && currentPhase != Phase[1]){
            currentPhase = Phase[1];
            isChangePhase = true;
        }
        else if(currentHealth >= 25 && currentHealth < 50 && currentPhase != Phase[2]){
            currentPhase = Phase[2];
            isChangePhase = true;
        }
        else if(currentHealth >= 50 && currentHealth < 75 && currentPhase != Phase[3]){
            currentPhase = Phase[3];
            isChangePhase = true;
        }
        else if(currentHealth >= 75 && currentHealth < 100 && currentPhase != Phase[4]){
            currentPhase = Phase[4];
            isChangePhase = true;
        }
        else if(currentHealth == 100 && currentPhase != Phase[5]){
            currentPhase = Phase[5];
            isChangePhase = true;
        }
    }
    public void ChangePhase(){
        Movement.instance.changeSpeed(phaseSpeed[currentPhase - 1]);

        Movement.instance.changeJumpPower(phaseJumpPower[currentPhase - 1]);

        Movement.instance.transform.localScale = new Vector3(phaseScale[currentPhase - 1], phaseScale[currentPhase - 1], phaseScale[currentPhase - 1]);
    }
    public void increaseHealthValue(InputAction.CallbackContext context){
        isIncreaseHealth = true;
        if(context.canceled){
            isIncreaseHealth = false;
            _increaseHealthTime = increaseHealthTime;
        }
    }
}
