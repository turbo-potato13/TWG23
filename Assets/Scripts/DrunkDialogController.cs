using TMPro;
using UnityEngine;

public class DrunkDialogController : MonoBehaviour
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
            Phrase22();
            countNode = 21;
        }

        if (m_Answ1 && countNode == 21)
        {
            RefreshAnswersBool();
            Phrase31();
            Invoke("DeactivateGameObjects", 2f);
        }

        if (m_Answ2 && countNode == 21)
        {
            RefreshAnswersBool();
            Phrase32();
            Invoke("DeactivateGameObjects", 2f);
        }
    }

    public void Phrase1()
    {
        countNode = 1;
        phrase.text = "Здарова! Отвези меня в бар. Трубы горят";
        answer1.text = "А ты че голый?";
        answer2.text = "Понимаю.";
    }

    public void Phrase21()
    {
        phrase.text = "Так я в стриптиз бар. Включи песню ... ";
        answer1.text = "Хорошо";
        answer2.text = "Нет";
    }

    public void Phrase22()
    {
        phrase.text = "Включи песню ...";
        answer1.text = "Хорошо";
        answer2.text = "Нет";
    }

    public void Phrase31()
    {
        phrase.text = "Оставлю тебе чаевых [блюет].";
        answer1.text = "";
        answer2.text = "";
    }

    public void Phrase32()
    {
        phrase.text = "Пидора ответ";
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
}