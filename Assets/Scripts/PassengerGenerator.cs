using System.Collections.Generic;
using UnityEngine;

public class PassengerGenerator : MonoBehaviour
{
    public List<GameObject> passengers;
    private int m_PassengerCount;
    private int m_MaxSize;

    private void Awake()
    {
        m_MaxSize = passengers.Count;
        foreach (var passenger in passengers)
        {
            passenger.SetActive(false);
        }

        passengers[0].SetActive(true);
    }

    public void NextPassenger()
    {
        passengers[m_PassengerCount].SetActive(false);
        m_PassengerCount++;
        if (m_PassengerCount < m_MaxSize)
            passengers[m_PassengerCount].SetActive(true);
    }

    public GameObject GetCurrentPassenger()
    {
        if (m_PassengerCount < m_MaxSize)
            return passengers[m_PassengerCount];
        else
            return null;
    }
}