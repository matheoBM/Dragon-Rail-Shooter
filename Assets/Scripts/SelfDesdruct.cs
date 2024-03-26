using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDesdruct : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy); 
    }
}
