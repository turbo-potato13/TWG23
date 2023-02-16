using System.Collections.Generic;
using UnityEngine;

public class TargetTaxiController : MonoBehaviour
{
    public List<Vector3> coordinates;
    public PassengerGenerator passengerGenerator;
    public GameObject target;
    private int m_MaxSize = 4;
    public float rotationSpeed = 10f;
    public GameObject panel;

    private int m_Counter;

    private void Start()
    {
        target.transform.position = coordinates[0];
        m_MaxSize = coordinates.Count;
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            m_Counter++;
            ShowNewTarget();
            passengerGenerator.NextPassenger();
            target.SetActive(false);
        }
    }

    public void ShowNewTarget()
    {
        if (m_Counter < m_MaxSize)
            target.transform.position = coordinates[m_Counter];
        else
        {
            Debug.Log("WTF");
            panel.SetActive(true);
            Invoke("EndGame", 3f);
        }
    }

    public Vector3 GetCurrentTarget()
    {
        if (m_Counter < m_MaxSize)
            return coordinates[m_Counter];
        else
            return Vector3.zero;
    }

    public void EndGame()
    {
        panel.SetActive(false);
    }
}