using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int currentScore;
    public bool isGamePaused;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        Time.timeScale = isGamePaused ? 0 : 1;

        GameUI.instance.TogglePauseMenu(isGamePaused);
    }

    public void AddScore(int score)
    {
        currentScore += score;

        GameUI.instance.UpdateScoreText(score);

        if(currentScore >= scoreToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        GameUI.instance.SetEndgameScreen(true, currentScore);
    }
}
