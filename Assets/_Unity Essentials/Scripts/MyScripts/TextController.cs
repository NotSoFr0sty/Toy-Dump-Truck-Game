using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {

    [SerializeField] private TMP_Text score;

    public void updateScoreText(int myScore) {

        score.text = "Score: " + myScore.ToString();
    }
}
