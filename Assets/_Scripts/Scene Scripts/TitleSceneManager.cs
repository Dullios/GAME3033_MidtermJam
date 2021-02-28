using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public GameObject buttonPanel;
    public GameObject creditPanel;

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ToggleCredits()
    {
        buttonPanel.SetActive(!buttonPanel.activeSelf);
        creditPanel.SetActive(!creditPanel.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
