using DefaultNamespace;
using UnityEngine;

public class PassengerScript : MonoBehaviour
{
    // public GameObject passenger;
    public GameObject taxi;
    public float pickupRadius = 2.0f;

    public bool isPickedUp;
    public bool isDroppedOff;
    private Rigidbody taxiRigidBody;

    public PassengerGenerator m_PassengerGenerator;
    public TargetTaxiController m_TargetTaxiController;
    public GameObject target;

    private void Start()
    {
        taxiRigidBody = taxi.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var passenger = m_PassengerGenerator.getCurrentPassenger();
        if (!isPickedUp)
        {
            float distance = Vector3.Distance(taxi.transform.position, passenger.transform.position);
            // Debug.Log(taxiRigidBody.velocity);
            //Условие чтобы пассажир сел
            // Debug.Log(distance);
            if (distance <= pickupRadius && taxiRigidBody.velocity == Vector3.zero)
            {
                target.SetActive(true);
                isPickedUp = true;
                m_TargetTaxiController.ShowNewTarget();
                // m_TargetTaxiController.SwitchIcon(true);
                passenger.transform.position = new Vector3(0, 0, 0);
                isDroppedOff = false;
            }
        }

        //Условие во время поездки
        if (isPickedUp && !isDroppedOff)
        {
            m_PassengerGenerator.DisableIconCurrentPassenger();
            var destination = m_TargetTaxiController.GetCurrentTarget();
            float distance = Vector3.Distance(taxi.transform.position, destination);
            Debug.Log(distance);
            //Условие что машина приехала
            if (distance <= pickupRadius)
            {
                isDroppedOff = true;
                passenger.transform.position = destination;
                passenger.SetActive(true);
            }
        }

        //Пассажир высаживается из машины
        if (isDroppedOff && taxiRigidBody.velocity == Vector3.zero)
        {
            passenger.transform.position = taxi.transform.position + new Vector3(2, 0, 2);
            passenger.SetActive(true);
            target.SetActive(false);
            // m_TargetTaxiController.SwitchIcon(false);
            m_PassengerGenerator.DisableCurrentPassenger();
        }
    }
}