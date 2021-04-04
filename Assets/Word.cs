using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Word {

    public string word;
    private int typeIndex;

    public static int CurrentScore = 0;
    public Text scoreText;
    public Text highScore;
 
    WordDisplay display;

    public Word (string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);     

    }


    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();

    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            display.RemoveWord();

            Score.CurrentScore += 1;
            if (CurrentScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", CurrentScore);
                highScore.text = CurrentScore.ToString();
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        return wordTyped;
    }
}
