using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{

    public static int CurrentScore = 0;

    public Text highScore;
    public Text scoreText;

    void Start()
    {
        scoreText.text = CurrentScore.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();     
    }

    void OnTriggerEnter2D()
    {
        Score.CurrentScore += 1;
        if (CurrentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", CurrentScore);
            highScore.text = CurrentScore.ToString();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Reset()
    {

        PlayerPrefs.DeleteKey("HighSCore");
    }


}
