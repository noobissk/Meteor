using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    static public bool IsPaused;
    static public int score;
    [SerializeField] int Level1ID;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] TMP_Text Score_T;
    float OriginTimeScale;
    void Start()
    {
        OriginTimeScale = Time.timeScale;
    }

    void Update()
    {
        Score_T.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused)
        {
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = false;
        }
        if (IsPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = OriginTimeScale;
        }
    }

    public void QUIT()
    {
        Application.Quit();
    }

    public void RestartGame01()
    {
        IsPaused = false;
        SceneManager.LoadScene(Level1ID);
        PauseMenu.SetActive(false);
    }
}
