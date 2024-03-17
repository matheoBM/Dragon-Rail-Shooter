using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        float newXPos = transform.localPosition.x + horizontalMovement * Time.deltaTime * movementSpeed;
        float newYPos = transform.localPosition.y + verticalMovement * Time.deltaTime * movementSpeed;

        newXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        newYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        {
            x = newXPos,
            y = newYPos,
            z = transform.localPosition.z
        };

    }
}
