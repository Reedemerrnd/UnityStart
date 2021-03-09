using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _newGame;
    [SerializeField]
    private Button _exit;

    private void Start()
    {
        _exit.onClick.AddListener(Exit);
        _newGame.onClick.AddListener(NewGame);
    }
    private void Exit()
    {
        Debug.Log("Exit app");
        Application.Quit();
    }
    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }

}
