using TMPro;
using UnityEngine;

public class DoctorDialogController : MonoBehaviour
{
    public TMP_Text phrase;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public DialogManager dialogManager;

    private bool m_Answer1;
    private bool m_Answer2;
    public int countNode;

    private void Start()
    {
        Phrase1();
    }

    private void Update()
    {
        if (m_Answer1 && countNode == 1)
        {
            RefreshAnswersBool();
            Phrase21();
            countNode = 21;
        }

        if (m_Answer2 && countNode == 1)
        {
            RefreshAnswersBool();
            Phrase22();
            countNode = 22;
        }

        if (m_Answer1 && countNode == 21)
        {
            RefreshAnswersBool();
            Phrase31();
            Invoke("DeactivateGameObjects", 2f);
        }

        if (m_Answer2 && countNode == 21)
            DeactivateGameObjects();

        if (m_Answer2 && countNode == 22)
        {
            RefreshAnswersBool();
            Phrase32();
            countNode = 31;
        }

        if (m_Answer1 && countNode == 22)
            DeactivateGameObjects();

        if ((m_Answer1 || m_Answer2) && countNode == 31)
            DeactivateGameObjects();


        if (countNode == -1)
            DeactivateGameObjects();
    }

    public void Phrase1()
    {
        countNode = 1;
        phrase.text = "Здравствуйте! Отвезите меня в больницу быстрее, от меня зависят жизни";
        answer1.text = "А что вы за врач?";
        answer2.text = "Вы проктолог?";
    }

    public void Phrase21()
    {
        phrase.text = "Да меня мама в реанимацию пристроила. Я там утки подношу.";
        answer1.text = "Которые крякают?";
        answer2.text = "Тогда, конечно, потороплюсь";
    }

    public void Phrase22()
    {
        phrase.text = "Нет. Но есть опыт. Нужна помощь?";
        answer1.text = "Нет, спасибо";
        answer2.text = "Да, у меня геморрой";
    }

    public void Phrase31()
    {
        phrase.text = "Да.";
        DisableParents(3);
        answer1.text = "";
        answer2.text = "";
    }

    public void Phrase32()
    {
        phrase.text = "Не, это уже сложно";
        answer1.text = "Ладно";
        answer2.text = "";
        DisableParents(2);
    }

    public void SetAnsw1()
    {
        m_Answer1 = true;
    }

    public void SetAnsw2()
    {
        m_Answer2 = true;
    }

    public void RefreshAnswersBool()
    {
        m_Answer1 = false;
        m_Answer2 = false;
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