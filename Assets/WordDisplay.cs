using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordDisplay : MonoBehaviour
{

    public Text text;
    public static float fallSpeed = 1f;
    public Slider speedSlider;
    public Text playingSpeedText;

    public void SetSpeed() //method for the slider on intro screen
    {

        fallSpeed = speedSlider.value;
        playingSpeedText.text = fallSpeed.ToString();
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);

    }

    void Start()
    {
        Destroy(gameObject, 20f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            Debug.Log("You LOST!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
