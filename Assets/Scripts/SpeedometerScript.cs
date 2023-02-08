using UnityEngine;

public class SpeedometerScript : MonoBehaviour
{
    public float start; // начальное положение стрелки по оси Z

    public float maxSpeed; // максимальная скорость на спидометре

    public RectTransform arrow; // стрелка спидометра

    public Transform target; // объект с которого берем скорость

    public float velocity; // текущая реальная скорость объекта

    private Rigidbody m_Rigidbody;
    private float m_Speed;

    void Start()
    {
        arrow.localRotation = Quaternion.Euler(0, 0, start);
        m_Rigidbody = target.GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocity = m_Rigidbody.velocity.magnitude;
        if (velocity > maxSpeed)
            velocity = maxSpeed;
        m_Speed = start - velocity * 10;
        arrow.localRotation = Quaternion.Euler(0, 0, m_Speed);
    }
}