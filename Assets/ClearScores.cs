using UnityEngine;
using UnityEngine.UI;

public class ClearScores : MonoBehaviour
{
    public static int CurrentScore = 0;

    public Text highScore;
    public Text scoreText;

    public void OnClick()
    {
        CurrentScore = 0;
        scoreText.text = CurrentScore.ToString();
    }
}
