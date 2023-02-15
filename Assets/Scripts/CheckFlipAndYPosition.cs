using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlipAndYPosition : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    private void Update()
    {
        // Check if the object has been flipped by more than 2 units in x or z
        if (Mathf.Abs(transform.rotation.eulerAngles.x) > 2 || Mathf.Abs(transform.rotation.eulerAngles.z) > 2)
        {
            // If x button is pressed, reset the rotation to x=0 and z=0
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            }
        }

        // Check if the object has fallen below y=-2
        if (transform.position.y < -2f)
        {
            // Reset the object to its initial position
            transform.position = startPosition;
        }
    }
}
