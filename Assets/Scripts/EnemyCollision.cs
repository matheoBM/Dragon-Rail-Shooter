using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject explosionParticles;
    [SerializeField] GameObject hitParticles;
    [SerializeField] Transform parentTransform;

    [Header("Scoring")]
    [SerializeField] int health = 40;
    [SerializeField] int hitPoint = 10;
    

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProecessHit();
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    void ProecessHit()
    {
        health -= hitPoint;
        scoreBoard.IncreaseScore(hitPoint);
        GameObject hitVFX = Instantiate(hitParticles, transform.position, Quaternion.identity);
        hitVFX.transform.parent = parentTransform;
        Debug.Log("Damage: " + hitPoint.ToString());
    }

    void KillEnemy()
    {
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        explosion.transform.parent = parentTransform;
        Destroy(gameObject);
    }
}
