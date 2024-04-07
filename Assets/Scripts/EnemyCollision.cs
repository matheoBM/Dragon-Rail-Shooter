using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitParticles;

    [Header("Scoring")]
    [SerializeField] int health = 40;
    [SerializeField] int hitPoint = 10;
    [SerializeField] int scorePoints = 10;
    

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
        Vector3 hitPosition = transform.position;
        hitPosition.y += 15;
        GameObject hitVFX = Instantiate(hitParticles, hitPosition, Quaternion.identity);
        hitVFX.transform.parent = parentGameObject.transform;
        Debug.Log("Damage: " + hitPoint.ToString());
    }

    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePoints);
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
