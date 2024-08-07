using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    private static UIManager instance;
    public static UIManager Instance {

        get {

            if (instance == null) {

                Debug.Log("UIManager is null");
            }
            return instance;
        }
    }

    private void Awake() {
        instance = this;
    }

    public void UpdateScoreDisplay(int score) {

        scoreText.text = "Score: " + score.ToString();
        if (score >= 35) {

            scoreText.text += "\tYou won!";
        }
    }
}
