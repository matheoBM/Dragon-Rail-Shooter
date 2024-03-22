using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("Horizontal and vertical movement speed")][SerializeField] float movementSpeed = 61;
    [Tooltip("Movement limit on the horizontal axis")][SerializeField] float xRange = 10f;
    [Tooltip("Movement limit on the vertical axis")][SerializeField] float yRange = 10f;

    [Header("Screen positioning based tuning")]
    [Tooltip("Factor to control position impact on pitch")][SerializeField] float positionPitchFactor = -1.5f;
    [Tooltip("Factor to control movement impact on pitch")][SerializeField] float positionYawFactor = 0.8f;

    [Header("Control based tuning")]
    [Tooltip("Factor to control movement impact on pitch")][SerializeField] float controlPitchFactor = -10f;
    [Tooltip("Factor to control movement impact on pitch")][SerializeField] float controlRollFactor = -15f;

    [Tooltip("Fire")][SerializeField] ParticleSystem dragonFire;

    float horizontalMovement, verticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessShooting();
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalMovement * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalMovement * controlRollFactor;

        Debug.Log("Rotation: " + Quaternion.Euler(pitch, yaw, roll));
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        float newXPos = transform.localPosition.x + horizontalMovement * Time.deltaTime * movementSpeed;
        float newYPos = transform.localPosition.y + verticalMovement * Time.deltaTime * movementSpeed;

        newXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        newYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        Debug.Log("Vertical Movement: " + verticalMovement);

        transform.localPosition = new Vector3
        {
            x = newXPos,
            y = newYPos,
            z = transform.localPosition.z
        };
    }

    void ProcessShooting() 
    {
        if (Input.GetButton("Fire1"))
        {
            SetEmissionActive(true);
        }
        else
        {
            SetEmissionActive(false);
        }

    }

    private void SetEmissionActive(bool isActive)
    {
        var emissionModule = dragonFire.emission;
        emissionModule.enabled = isActive;
    }
}
