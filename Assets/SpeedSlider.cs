using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    public static float fallSpeed = 1f;
    public Slider speedSlider;
    public Text playingSpeedText;

    public void SetSpeed() //method for the slider on intro screen
    {

        fallSpeed = speedSlider.value;
        playingSpeedText.text = fallSpeed.ToString();
    }
}
