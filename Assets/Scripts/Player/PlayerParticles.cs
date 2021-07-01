using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public GameObject SlimeParticle;

    public void SpawnPartiles(GameObject _particle, Transform transform){
        Instantiate(_particle, transform.position, transform.rotation);
    }
}
