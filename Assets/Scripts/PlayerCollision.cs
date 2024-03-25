using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float reloadTime = 1f;
    [SerializeField] ParticleSystem explosionParticles;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger: "+ gameObject.ToString() + " trigered by " + other.gameObject.ToString());
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        explosionParticles.Play();
        Invoke("ReloadScene", reloadTime);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
