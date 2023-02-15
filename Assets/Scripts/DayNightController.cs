using UnityEngine;

[ExecuteInEditMode]
public class DayNightController : MonoBehaviour
{
    public Gradient directionalLightGradient;
    public Gradient ambientLightGradient;

    [SerializeField, Range(1, 3600)] private float timeDayInSeconds = 300;
    [SerializeField, Range(0.2f, 0.8f)] private float timeProgress;

    public Light dirLight;
    private Vector3 m_DefaultAngels;

    void Start()
    {
        m_DefaultAngels = dirLight.transform.localEulerAngles;
    }

    void Update()
    {
        if (Application.isPlaying)
            timeProgress += Time.deltaTime / timeDayInSeconds;

        if (timeProgress > 0.8f)
            timeProgress = 0.2f;

        dirLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        dirLight.transform.localEulerAngles =
            new Vector3(360f * timeProgress - 90, m_DefaultAngels.x, m_DefaultAngels.z);
    }
}