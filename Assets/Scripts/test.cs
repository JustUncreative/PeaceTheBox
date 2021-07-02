using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class test : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    private void Update() {
        cam.m_Lens.OrthographicSize = 10;
    }
}
