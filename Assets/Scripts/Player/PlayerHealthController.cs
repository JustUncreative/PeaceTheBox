using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealthController : MonoBehaviour
{
    private bool _isDie;
    private Rigidbody2D rb => Movement.instance.rb;
    public bool _isAlive => IsAlive(currentHealth);
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
    [SerializeField] private Vector2 _deathKick = new Vector2(0f, 2f);
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        _changePhaseTime = changePhaseTime;
        _increaseHealthTime = increaseHealthTime;

        DetectPhase();
        //ChangePhase();
    }

    void Update()
    {
        if(isChangePhase && !StuckCheck.instance._isStuck){
            _changePhaseTime -= Time.deltaTime;

            //animation

            if(_changePhaseTime < 0){
                DetectPhase();

                _changePhaseTime = changePhaseTime;

                transform.position = new Vector3(transform.position.x, transform.position.y + phaseScale[currentPhase - 1]/2, transform.position.z);
                 
                ChangePhase();
            }

        }

        if(isIncreaseHealth){
            _increaseHealthTime -= Time.deltaTime;

            if(_increaseHealthTime < 0){

                _increaseHealthTime = increaseHealthTime;

                ReduceHealthPoints(increaseHealth);

                DetectPhase();
            }
        }
    }
    private void FixedUpdate() {
        if(!_isAlive && !_isDie){
            _isDie = true;

            Die();
        }
    }

    public void ReduceHealthPoints(float Points){
        if(IsAlive(currentHealth)){
            currentHealth -= Points;
        }

            DetectPhase();
    }
    public void AddHealthPoints(float Points){
        if(IsAlive(currentHealth) && currentHealth < maxHealth){
            currentHealth += Points;
        }

        EditCurrentHealth();

        DetectPhase();
    }
    public bool IsAlive(float health){
        if(health > 0){
            return true;
        }
        else{
            return false;
        }
    }
    public void EditCurrentHealth(){
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
    public void DetectPhase(){
        if(currentHealth == 1f && currentPhase != Phase[0]){
            currentPhase = Phase[0];
            isChangePhase = true;
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

        transform.localScale = new Vector3(phaseScale[currentPhase - 1], phaseScale[currentPhase - 1], phaseScale[currentPhase - 1]);

        isChangePhase = false;
    }
    public void increaseHealthValue(InputAction.CallbackContext context){
        isIncreaseHealth = true;
        if(context.canceled){
            isIncreaseHealth = false;
            _increaseHealthTime = increaseHealthTime;
        }
    }
    public void Die(){
        rb.velocity = _deathKick;
    }
}
