using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTilemap : MonoBehaviour
{
    public static groundTilemap instance;
    private Vector3 position;
    private float offsetPos;
    private bool Right;
    [SerializeField] private float smearSpeed;
    private void Awake() {
        instance = this;

    }
    public Transform groundTilemapPosition;
    private void FixedUpdate() {

        /*float horizontal = Movement.instance.horizontal;

        if(horizontal != 0){
            offsetPos = horizontal/System.Math.Abs(horizontal) * Movement.instance.transform.localScale.x/2 * 0.9f;
        }else {
            offsetPos = horizontal * Movement.instance.transform.localScale.x/2 * 0.9f;
        }
        
        Vector3 position = Movement.instance.transform.position;

        transform.position = new Vector3(position.x + offsetPos, transform.position.y, position.z);*/

        if(transform.localPosition.x > 0.45f){
            Right = false;
        }else if(transform.localPosition.x < -0.45f){
            Right = true;
        }

        if(!Right){
            transform.localPosition = new Vector3(transform.localPosition.x - smearSpeed, transform.localPosition.y, transform.localPosition.z);
        }else if(Right){
            transform.localPosition = new Vector3(transform.localPosition.x + smearSpeed, transform.localPosition.y, transform.localPosition.z);
        }

    }

        
}
