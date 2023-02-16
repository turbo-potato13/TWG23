using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject panel;
    private bool m_IsPanelActive;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!m_IsPanelActive)
                ShowPausePanel();
            else
                DisablePausePanel();
        }
    }

    public void ShowPausePanel()
    {
        m_IsPanelActive = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void DisablePausePanel()
    {
        m_IsPanelActive = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}