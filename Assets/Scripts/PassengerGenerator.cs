using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PassengerGenerator : MonoBehaviour
    {
        public List<GameObject> passengers;
        public int passengerCount;
        
        private void Awake()
        {
            foreach (var passenger in passengers)
            {
                passenger.SetActive(false);  
            }
            passengers[0].SetActive(true);
        }

        public void nextPassenger()
        {
            passengerCount++;
            passengers[passengerCount].SetActive(true);
        }

        public GameObject getCurrentPassenger()
        {
            
            return passengers[passengerCount];
        }

        public void DisableCurrentPassenger()
        {
            passengers[passengerCount].SetActive(false);
        }

        public void DisableIconCurrentPassenger()
        {
            foreach (Transform child in  passengers[passengerCount].transform) 
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}