using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
public class TargetTaxiController : MonoBehaviour
{
    public List<Vector3> coordinates;
    public PassengerGenerator m_PassengerGenerator;

    private int counter;
    public GameObject Icon;
    private void Start()
    {
        transform.position = coordinates[0];
    }

    public void SwitchIcon(bool enabled)
    {
        Debug.Log("SwitchIcon" + enabled);
        Icon.SetActive(enabled);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            m_PassengerGenerator.nextPassenger();

            // insideSquare = true;
            Debug.Log("enter");
            counter++;
            ShowNewTarget();
        }
    }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag.Equals("Player"))
    //     {
    //         // insideSquare = false;
    //     }
    // }

    
    public void ShowNewTarget()
    {
        transform.position = coordinates[counter];
    }

    public Vector3 GetCurrentTarget()
    {
        return coordinates[counter];
    }

    // void Update()
    // {
    //     if (insideSquare)
    //     {
    //         transform.position = coordinates[counter];
    //     }
    // }
}

