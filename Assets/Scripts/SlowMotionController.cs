using UnityEngine;

public class SlowMotionController : MonoBehaviour
{
    public float slowMotionFactor = 2.0f; 
    public float constantIncreaseSpeed = 0.5f; 
    public float constantDecreaseSpeed = 0.5f; 
    public float constant = 10.0f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 1.0f / slowMotionFactor;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            Time.timeScale = 1.0f;
        }

        if (Input.GetKey(KeyCode.X))
        {
            constant -= constantDecreaseSpeed * Time.deltaTime;
        }
        else
        {
            constant += constantIncreaseSpeed * Time.deltaTime;
        }
    }
}
