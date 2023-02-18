using UnityEngine;

public class CarEqulaser : MonoBehaviour
{
    private Vector3 m_CurrentPosition;
    private float m_TimeSinceLastMove;
    public NpcMachine npcMachine;
    public float marginOfError = 0.1f;

    private void Start()
    {
        m_CurrentPosition = transform.position;
        m_TimeSinceLastMove = 0;
    }

    private void Update()
    {
        var isStandingStill = Vector3.Distance(transform.position, m_CurrentPosition) <= marginOfError;

        if (isStandingStill)
        {
            m_TimeSinceLastMove += Time.deltaTime;
            if (m_TimeSinceLastMove >= 5)
            {
                transform.position = npcMachine.GetCurrentVector();
                m_CurrentPosition = transform.position;
                m_TimeSinceLastMove = 0;
            }
        }
        else
        {
            m_CurrentPosition = transform.position;
            m_TimeSinceLastMove = 0;
        }
    }
}