using UnityEngine;

public class CheckFlipAndYPosition : MonoBehaviour
{
    private Vector3 m_StartPosition;

    private void Start()
    {
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.x) > 2 || Mathf.Abs(transform.rotation.eulerAngles.z) > 2)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            }
        }

        if (transform.position.y < -2f)
        {
            transform.position = m_StartPosition;
        }
    }
}