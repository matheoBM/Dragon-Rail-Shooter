using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;

    [SerializeField] float positionPitchFactor = -1.5f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlYawFactor = 0.8f;
    [SerializeField] float controlRollFactor = -15f;

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
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalMovement * controlPitchFactor;
        float yaw = transform.localPosition.x * controlYawFactor;
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
}
