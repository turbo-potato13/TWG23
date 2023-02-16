using UnityEngine;

public class JumpOnClick : MonoBehaviour
{
    public float jumpHeight = 1f;
    public float jumpTime = 0.5f;

    private bool m_IsJumping;
    private float m_JumpTimer;
    private Vector3 m_StartPos;

    void Start()
    {
        m_StartPos = transform.position;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            m_IsJumping = true;
        }
    }

    void Update()
    {
        if (m_IsJumping)
        {
            m_JumpTimer += Time.deltaTime;

            float fracComplete = m_JumpTimer / jumpTime;
            transform.position = m_StartPos + Vector3.up * Mathf.Sin(fracComplete * Mathf.PI) * jumpHeight;

            if (m_JumpTimer >= jumpTime)
            {
                m_IsJumping = false;
                m_JumpTimer = 0f;

                transform.position = m_StartPos;
            }
        }
    }
}