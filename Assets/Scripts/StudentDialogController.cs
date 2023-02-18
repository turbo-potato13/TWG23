using TMPro;
using UnityEngine;

public class StudentDialogController : MonoBehaviour
{
    public TMP_Text phrase;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public DialogManager dialogManager;

    private bool m_Answ1;
    private bool m_Answ2;
    public int countNode;

    private void Start()
    {
        Phrase1();
    }

    private void Update()
    {
        if (m_Answ1 && countNode == 1)
        {
            RefreshAnswersBool();
            Phrase21();
            countNode = 21;
        }

        if (m_Answ2 && countNode == 1)
        {
            RefreshAnswersBool();
            Phrase31();
            countNode = 22;
        }

        if ((m_Answ1 || m_Answ2) && countNode == 21)
        {
            RefreshAnswersBool();
            Phrase31();
            countNode = 22;
        }

        if (m_Answ1 && countNode == 22)
        {
            RefreshAnswersBool();
            DeactivateGameObjects();
        }

        if (m_Answ2 && countNode == 22)
        {
            RefreshAnswersBool();
            Phrase32();
            Invoke("DeactivateGameObjects", 2f);
        }
    }

    public void Phrase1()
    {
        countNode = 1;
        phrase.text = "Мне в университет, и побыстрее, на зачет опаздываю";
        answer1.text = "Какой зачет?";
        answer2.text = "Зачем тебе этот универ. Иди таксистом, работа кайф";
    }

    public void Phrase21()
    {
        phrase.text = "Компьютерная безопасность";
        answer1.text = "И че они в большой опасности?)";
        answer2.text = "Ты хоть в армии служил?";
    }

    public void Phrase31()
    {
        phrase.text = "Давайте лучше музыку послушаем.";
        answer1.text = "Хорошо";
        answer2.text = "Нет";
    }

    public void Phrase32()
    {
        phrase.text = "Пидора ответ";
        DisableParents(3);
        answer1.text = "";
        answer2.text = "";
    }

    public void SetAnsw1()
    {
        m_Answ1 = true;
    }

    public void SetAnsw2()
    {
        m_Answ2 = true;
    }

    public void RefreshAnswersBool()
    {
        m_Answ1 = false;
        m_Answ2 = false;
    }

    public void DeactivateGameObjects()
    {
        dialogManager.DeactivateGameObjects();
    }

    public void DisableParents(int code)
    {
        switch (code)
        {
            case 1:
                answer1.transform.parent.gameObject.SetActive(false);
                break;
            case 2:
                answer2.transform.parent.gameObject.SetActive(false);
                break;
            case 3:
                answer1.transform.parent.gameObject.SetActive(false);
                answer2.transform.parent.gameObject.SetActive(false);
                break;
        }
    }
}