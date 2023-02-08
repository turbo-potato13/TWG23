using UnityEngine;

public class PassengerController : MonoBehaviour
{
    public GameObject taxi;
    public PassengerGenerator passengerGenerator;
    public TargetTaxiController targetTaxiController;
    public bool isPickedUp;
    public bool isDroppedOff;
    private Rigidbody m_TaxiRigidBody;
    public float pickupRadius = 2.0f;
    public GameObject target;

    private void Start()
    {
        m_TaxiRigidBody = taxi.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var passenger = passengerGenerator.GetCurrentPassenger();
        if (!isPickedUp)
        {
            float distance = Vector3.Distance(taxi.transform.position, passenger.transform.position);
            //Условие чтобы пассажир сел
            if (distance <= pickupRadius && m_TaxiRigidBody.velocity == Vector3.zero)
            {
                PassengerSitsDown(passenger);
            }
        }

        //Условие во время поездки
        if (isPickedUp && !isDroppedOff)
        {
            var destination = targetTaxiController.GetCurrentTarget();
            float distance = Vector3.Distance(taxi.transform.position, destination);
            //Условие что машина приехала
            if (distance <= pickupRadius)
            {
                isPickedUp = false;
                isDroppedOff = true;
                passenger.transform.position = destination;
                passenger.SetActive(true);
            }
        }
    }

    private void PassengerSitsDown(GameObject passenger)
    {
        target.SetActive(true);
        isPickedUp = true;
        targetTaxiController.ShowNewTarget();
        passenger.transform.position = new Vector3(1000, 1000, 1000);
    }
}