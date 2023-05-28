using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("Endgame screen")]
    public GameObject endgameScreenObject;
    public TextMeshProUGUI endgameHeaderText;
    public TextMeshProUGUI endgameScoreText;

    public static GameUI instance;


    private void Awake()
    {
        instance = this;    
    }

    public void UpdateHealthBar(int currentHp, int maxHp)
    {
        healthBarFill.fillAmount = (float)currentHp/maxHp;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateAmmoText(int currentAmmo, int maxAmmo)
    {
        ammoText.text = $"Ammo: {currentAmmo} / {maxAmmo}";
    }

    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void SetEndgameScreen(bool gameWon, int score)
    {
        endgameScreenObject.SetActive(true);

        endgameHeaderText.text = gameWon ? "You win" : "You lose";
        endgameHeaderText.color = gameWon ? Color.green : Color.red;

        endgameScoreText.text = $"<b>Score</b>\n{score}";
    }

    public void OnResumeButtonClick()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
