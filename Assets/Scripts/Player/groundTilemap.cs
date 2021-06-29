using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTilemap : MonoBehaviour
{
    public static groundTilemap instance;
    private Vector3 borderPos;
    private Vector3 position;
    private void Awake() {
        instance = this;
        
        float horizontal = Movement.instance.horizontal;
        float offsetPos = horizontal * Movement.instance.transform.localScale.x/2 * 0.95f;
        Vector3 position = Movement.instance.transform.position;
        Vector3 borderPos = new Vector3(position.x + offsetPos, transform.position.y, position.z);
    }
    public Transform groundTilemapPosition;
    private void FixedUpdate() {
        //float horizontal = Movement.instance.horizontal;
        float offsetPos = Movement.instance.transform.localScale.x/2 * 0.95f;
        Vector3 position = Movement.instance.transform.position;

        transform.position = new Vector3(position.x - offsetPos, transform.position.y, position.z);

        while(transform.position != borderPos){
            position = Movement.instance.transform.position;

            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        }
    }
}
