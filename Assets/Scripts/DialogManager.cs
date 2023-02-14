using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject doctorDialog;
    public GameObject drunkDialog;
    public GameObject studentDialog;
    public GameObject pigDialog;
    public List<GameObject> gameObjects;

    public void Start()
    {
        DeactivateGameObjects();
    }

    public void EnableDialogByNumber(int num)
    {
        DisableAllDialogs();
        switch (num)
        {
            case 0:
                doctorDialog.SetActive(true);
                doctorDialog.GetComponent<DoctorDialogController>().RefreshAnswersBool();
                doctorDialog.GetComponent<DoctorDialogController>().countNode = 1;
                break;
            case 1:
                drunkDialog.SetActive(true);
                drunkDialog.GetComponent<DrunkDialogController>().RefreshAnswersBool();
                drunkDialog.GetComponent<DrunkDialogController>().countNode = 1;
                break;
            case 2:
                studentDialog.SetActive(true);
                studentDialog.GetComponent<StudentDialogController>().RefreshAnswersBool();
                studentDialog.GetComponent<StudentDialogController>().countNode = 1;
                break;
            case 3:
                pigDialog.SetActive(true);
                pigDialog.GetComponent<PigDialogController>().RefreshAnswersBool();
                pigDialog.GetComponent<PigDialogController>().countNode = 1;
                break;
        }
    }

    private void DisableAllDialogs()
    {
        doctorDialog.SetActive(false);
        drunkDialog.SetActive(false);
        studentDialog.SetActive(false);
        pigDialog.SetActive(false);
    }

    public void DeactivateGameObjects()
    {
        foreach (var gameObj in gameObjects)
        {
            gameObj.SetActive(false);
        }
    }

    public void ActivateGameObjects()
    {
        foreach (var gameObj in gameObjects)
        {
            gameObj.SetActive(true);
        }
    }
}