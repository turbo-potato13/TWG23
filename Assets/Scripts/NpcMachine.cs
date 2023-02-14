using System.Collections.Generic;
using UnityEngine;

public class NpcMachine : MonoBehaviour
{
    public List<Vector3> waypoints;
    public float speed = 5f;
    public float rotationSpeed = 2f;
    public float detectionRange = 5f;
    public LayerMask obstacleMask;

    private int m_CurrentWaypoint;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        transform.position = waypoints[m_CurrentWaypoint];
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = waypoints[m_CurrentWaypoint] - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        if (Physics.Raycast(transform.position, transform.forward, out _, detectionRange, obstacleMask))
        {
            m_Rigidbody.velocity = Vector3.zero;
            return;
        }

        m_Rigidbody.velocity = transform.forward * speed;

        if (Vector3.Distance(transform.position, waypoints[m_CurrentWaypoint]) < 1f)
        {
            m_CurrentWaypoint = (m_CurrentWaypoint + 1) % waypoints.Count;
        }
    }
}