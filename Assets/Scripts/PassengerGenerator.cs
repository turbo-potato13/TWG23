using System.Collections.Generic;
using UnityEngine;

public class PassengerGenerator : MonoBehaviour
{
    public List<GameObject> passengers;
    private int m_PassengerCount;

    private void Awake()
    {
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
        passengers[m_PassengerCount].SetActive(true);
    }

    public GameObject GetCurrentPassenger()
    {
        return passengers[m_PassengerCount];
    }
}