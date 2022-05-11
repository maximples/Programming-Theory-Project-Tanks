using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI TextDif;
    public  GameObject menuWin;
    public  GameObject menuLose;
    public GameObject menu;
    public GameObject menuDif;
    public GameObject Player;
    public bool activ = true;
    private void Start()
    {
        Instance = this;

        

    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public  void Win()
    {
        activ = false;
        Destroy(Player);
        menuWin.SetActive(true);
    }
    public void Lose()
    {
        activ = false;
        Destroy(Player);
        menuLose.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuBack()
    {
        menuDif.SetActive(false);
        menu.SetActive(true); 
    }
    public void MenuDifficulty()
    {
        menu.SetActive(false);
        menuDif.SetActive(true);

    }
    public void Easy()
    {

        SaveData.Instance.DifficultyCorrect(0.5f);
        TextDif.text = "Это не серьёзно";
    }
    public void Normal()
    {
        SaveData.Instance.DifficultyCorrect(1);
        TextDif.text = "Стандарт.Скучно.";
    }
    public void Hard()
    {
        SaveData.Instance.DifficultyCorrect(1.2f);
        TextDif.text = "Будет интересно...";
    }
    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
