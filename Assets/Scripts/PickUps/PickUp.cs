using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float pointsToAdd;
    [SerializeField] private GameObject pickupEffect;

    private bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            //PlayerHealthController.instance.AddPointToPlayer(pointsToAdd);

            isCollected = true;
            Destroy(gameObject);

            Instantiate(pickupEffect, transform.position, transform.rotation);
        }

    }
}
