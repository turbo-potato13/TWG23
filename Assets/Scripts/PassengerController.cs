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
    public DialogManager dialogManager;

    private void Start()
    {
        dialogManager.DeactivateGameObjects();
        m_TaxiRigidBody = taxi.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var passenger = passengerGenerator.GetCurrentPassenger();
        if (passenger == null)
            return;

        if (!isPickedUp)
        {
            float distance = Vector3.Distance(taxi.transform.position, passenger.transform.position);
            // Debug.Log(distance);
            //Условие чтобы пассажир сел
            if (distance <= pickupRadius && m_TaxiRigidBody.velocity == Vector3.zero)
            {
                PassengerSitsDown(passenger);
            }
        }

        //Условие во время поездки
        if (isPickedUp)
        {
            var destination = targetTaxiController.GetCurrentTarget();
            float distance = Vector3.Distance(taxi.transform.position, destination);
            //Условие что машина приехала
            if (distance <= 6)
            {
                isPickedUp = false;
                passenger.transform.position = new Vector3(destination.x, 0.85f, destination.z);
                passenger.SetActive(true);
                dialogManager.DeactivateGameObjects();
            }
        }
    }

    private void PassengerSitsDown(GameObject passenger)
    {
        target.SetActive(true);
        isPickedUp = true;
        targetTaxiController.ShowNewTarget();
        passenger.transform.position = new Vector3(1000, 1000, 1000);
        dialogManager.ActivateGameObjects();
    }
}