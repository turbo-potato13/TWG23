using TMPro;
using UnityEngine;

public class PigDialogController : MonoBehaviour
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
        if ((m_Answ1 || m_Answ2) && countNode == 1)
        {
            RefreshAnswersBool();
            Phrase2();
            countNode = 31;
        }

        if (m_Answ1 && countNode == 31)
        {
            RefreshAnswersBool();
            Phrase31();
            Invoke("DeactivateGameObjects", 2f);
        }

        if (m_Answ2 && countNode == 31)
        {
            RefreshAnswersBool();
            Phrase32();
            Invoke("DeactivateGameObjects", 2f);
        }
    }

    public void Phrase1()
    {
        countNode = 1;
        phrase.text = "Давай быстрее я организатор на конкурсе игр. Такую тему придумал";
        answer1.text = "Что за тема?";
        answer2.text = "";
    }

    public void Phrase2()
    {
        phrase.text = "Остановись, мгновенье, ты прекрасно!";
        answer1.text = "Ого, какая интересная тема";
        answer2.text = "Ну и мразь же ты";
    }

    public void Phrase31()
    {
        phrase.text = "Спасибо!";
        answer1.text = "";
        answer2.text = "";
    }

    public void Phrase32()
    {
        phrase.text = "Я знаю";
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