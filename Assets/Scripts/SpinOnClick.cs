using UnityEngine;

public class SpinOnClick : MonoBehaviour
{
    public float spinSpeed = 10f;
    public float spinTime = 1f;

    private bool m_IsSpinning;
    private float m_SpinTimer;

    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            m_IsSpinning = true;
        }
    }

    void Update()
    {
        if (m_IsSpinning)
        {
            m_SpinTimer += Time.deltaTime;

            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y += spinSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);

            if (m_SpinTimer >= spinTime)
            {
                m_IsSpinning = false;
                m_SpinTimer = 0f;
            }
        }
    }
}