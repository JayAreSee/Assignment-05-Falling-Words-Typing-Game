
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
  
            Debug.Log("You LOST!");
            SceneManager.LoadScene(2);
            //Score.CurrentScore = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
