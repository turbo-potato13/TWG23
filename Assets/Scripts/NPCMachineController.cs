using UnityEngine;

public class NpcMachineController : MonoBehaviour
{
    public float squareSide = 10f;
    public float speed = 1f;

    private Vector3 _startPosition;
    private int _direction = 1;

    private bool _obstacleDetected;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        _obstacleDetected = CheckForObstacle();
        // if (!_obstacleDetected)
            MoveCar();


        if (CheckTurn())
            TurnCar();
    }

    private bool CheckForObstacle()
    {
        return Physics.Raycast(transform.position, transform.forward, 5f);
    }

    private void MoveCar()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private bool CheckTurn()
    {
        return (transform.position - _startPosition).magnitude % squareSide < 0.1f;
    }

    private void TurnCar()
    {
        _direction *= -1;
        transform.Rotate(Vector3.up, 90 * _direction);
    }
}