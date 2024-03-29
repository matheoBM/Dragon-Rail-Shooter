using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject explosionParticles;
    [SerializeField] GameObject hitParticles;

    [Header("Scoring")]
    [SerializeField] int health = 40;
    [SerializeField] int hitPoint = 10;
    

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        Debug.Log(parentGameObject);
        if (parentGameObject == null)
        {
            Debug.LogWarning("No object for spawning particles was created");
        }
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
        hitVFX.transform.parent = parentGameObject.transform;
        Debug.Log("Damage: " + hitPoint.ToString());
    }

    void KillEnemy()
    {
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        explosion.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
