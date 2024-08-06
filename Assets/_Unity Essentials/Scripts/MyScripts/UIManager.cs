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

    public void UpdateScoreDisplay(int points) {

        scoreText.text = "Score: " + points.ToString();
    }
}
