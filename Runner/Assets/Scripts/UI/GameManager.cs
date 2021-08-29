using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartWindow;
    public GameObject FinishWindow;
    public Button StartButton;
    public Button RestartButton;
    public PlayerMovements PlayerScript;

    void Awake()
    {
        StartWindow.SetActive(true);
        FinishWindow.SetActive(false);
        StartButton.onClick.AddListener(StartGame);
        RestartButton.onClick.AddListener(RestartGame);
    }

    void StartGame()
    {
        PlayerScript.StopPlayer(false);
        StartWindow.SetActive(false);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StopGame()
    {
        PlayerScript.StopPlayer(true);
        PlayerScript.Winned(true);
        FinishWindow.SetActive(true);
    }
}
