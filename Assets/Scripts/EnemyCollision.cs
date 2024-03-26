using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject explosionParticles;
    [SerializeField] Transform parentTransform;
    [SerializeField] int enemyScore = 10;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProecessHit();
        KillEnemy();
    }

    void ProecessHit()
    {
        scoreBoard.IncreaseScore(enemyScore);
    }

    void KillEnemy()
    {
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        explosion.transform.parent = parentTransform;
        Destroy(gameObject);
    }
}
