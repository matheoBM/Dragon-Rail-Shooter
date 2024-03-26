using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject explosionParticles;
    [SerializeField] Transform parentTransform;

    void OnParticleCollision(GameObject other)
    {
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        explosion.transform.parent = parentTransform;
        Destroy(gameObject);
    }
}
