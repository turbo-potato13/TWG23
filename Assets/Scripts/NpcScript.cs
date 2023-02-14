using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public float speed = 10f;
    public float xMin = -5f;
    public float xMax = 5f;
    public float zMin = -5f;
    public float zMax = 5f;
    public float obstacleDetectionRadius = 1f;
    public LayerMask obstacleLayer;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        while (true)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            Vector3 targetPosition = new Vector3(x, 0, z);
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Check if there's an obstacle in the way
            if (Physics.SphereCast(transform.position, obstacleDetectionRadius, direction, out RaycastHit hit, Mathf.Infinity, obstacleLayer))
            {
                // If there's an obstacle, turn 180 degrees
                direction = -direction;
            }

            rigidbody.velocity = direction * speed;
            yield return new WaitForFixedUpdate();
        }
    }
}
