using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float reloadTime = 1f;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger: "+ gameObject.ToString() + " trigered by " + other.gameObject.ToString());
        GetComponent<PlayerController>().enabled = false;
        Invoke("CrashSequence", reloadTime);
    }

    void CrashSequence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
