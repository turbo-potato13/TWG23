using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_Text loadingText;
    public GameObject loadingPanel;
    private AsyncOperation m_LoadingAsyncOperation;

    public void LoadGame()
    {
        loadingPanel.SetActive(true);
        m_LoadingAsyncOperation = SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (m_LoadingAsyncOperation != null)
        {
            loadingText.text = "Загрузка " + Mathf.RoundToInt(m_LoadingAsyncOperation.progress * 100) + "%";
        }
    }
}