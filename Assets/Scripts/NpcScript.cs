using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public float speed = 5f;
    public List<Vector3> movePoints;
    private Vector3 m_TargetPoint;
    private bool m_ObstacleDetected;


    void Start()
    {
        m_TargetPoint = movePoints[0];
    }


    void Update()
    {
        if (transform.position == m_TargetPoint)
        {
            ChooseNewTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, m_TargetPoint, speed * Time.deltaTime);
    }

    private void ChooseNewTarget()
    {
        if (m_ObstacleDetected)
        {
            m_TargetPoint = movePoints[Random.Range(0, movePoints.Count)];
            m_ObstacleDetected = false;
            return;
        }

        int randomIndex = Random.Range(0, movePoints.Count);
        m_TargetPoint = movePoints[randomIndex];

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (m_TargetPoint - transform.position), out hit,
                Vector3.Distance(transform.position, m_TargetPoint)))
        {
            m_ObstacleDetected = true;
        }
    }
}