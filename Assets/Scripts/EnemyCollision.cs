using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
