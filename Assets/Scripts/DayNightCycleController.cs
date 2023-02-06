using UnityEngine;

public class DayNightCycleController : MonoBehaviour
{
    public Light sun;

    private float _currentTime;
    [SerializeField] private float transitionSpeed = 0.005f;
    private static readonly int Exposure = Shader.PropertyToID("_Exposure");

    void Update()
    {
        _currentTime += Time.deltaTime * transitionSpeed;
        _currentTime %= 1f;
        if (_currentTime > 0.2f)
            RenderSettings.skybox.SetFloat(Exposure, _currentTime);

        sun.transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime);
        sun.transform.LookAt(Vector3.zero);
    }
}