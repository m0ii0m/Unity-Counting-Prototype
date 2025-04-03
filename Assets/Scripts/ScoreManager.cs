using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int lives;
    public bool gameOver;
    public TextMeshProUGUI scoreMesh;
    public TextMeshProUGUI gameOverMesh;
    public TextMeshProUGUI livesMesh;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        AddScore(0);
        lives = 3;
        livesMesh.text = "Lives: " + lives;
        gameOver = false;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreMesh.text = "Score: " + score;
        if(value < 0) LoseLife();
    }

    public void LoseLife()
    {
        lives--;
        livesMesh.text = "Lives: " + lives;
        if (lives <= 0)
        {
            gameOver = true;
            gameOverMesh.gameObject.SetActive(true);
        }
    }
}