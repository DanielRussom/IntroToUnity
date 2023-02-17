using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int scoreToGive = 1;
    public int clicksToPop = 5;
    public float scareIncreasePerClick = 0.1f;
    public ScoreManager scoreManager;

    void OnMouseDown()
    {
        clicksToPop--;

        transform.localScale += Vector3.one * scareIncreasePerClick;

        if(clicksToPop <= 0)
        {
            scoreManager.IncreaseScore(scoreToGive);
            Destroy(gameObject);
        }
    }
}
