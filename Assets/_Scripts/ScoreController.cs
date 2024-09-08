using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    private TMP_Text scoreText;
    float scoreValue = 0;
    void Awake() {
        instance = this;
        scoreText = GetComponent<TMP_Text>();
    }
    public void UpdateScore(float value) {
        scoreValue = value;
        scoreText.text = scoreValue.ToString();
    }

}
