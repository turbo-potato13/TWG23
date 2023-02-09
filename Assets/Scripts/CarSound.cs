using UnityEngine;

public class CarSound : MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 16;
    private float m_CurrentSpeed;

    private Rigidbody m_Rigidbody;
    private AudioSource m_CarSound;

    public float minPitch = 0.1f;
    public float maxPitch = 0.5f;
    private float m_PitchFromCar;

    private void Start()
    {
        m_CarSound = GetComponent<AudioSource>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        EngineSound();
    }

    private void EngineSound()
    {
        var velocity = m_Rigidbody.velocity;
        m_CurrentSpeed = velocity.magnitude;
        m_PitchFromCar = velocity.magnitude / 50f;

        if (m_CurrentSpeed < minSpeed)
            m_CarSound.pitch = minPitch;
        if (m_CurrentSpeed > minSpeed && m_CurrentSpeed < maxSpeed)
            m_CarSound.pitch = minPitch + m_PitchFromCar + 0.1f;
        if (m_CurrentSpeed > maxSpeed)
            m_CarSound.pitch = maxPitch;
    }
}