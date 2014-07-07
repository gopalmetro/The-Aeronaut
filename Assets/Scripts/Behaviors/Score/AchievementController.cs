using UnityEngine;
using System.Collections;

public class AchievementController : MonoBehaviour {

    public GUIText AwesomeImage = null;
    public GUIText YellowPowerUp = null;
    public GUIText GreenPowerUp = null;

    private static AchievementController scoreManager = null;
    private int score = 0;
    private int messageTimer;

    void Start() {
        DontDestroyOnLoad(this);
        messageTimer = 0;
        NotificationCenter.defaultCenter.addListener(onReceiveMessageSetMessageVisible, NotificationType.OnAchievableEvent);
        AwesomeImage.gameObject.SetActive(false);
        YellowPowerUp.gameObject.SetActive(false);
        GreenPowerUp.gameObject.SetActive(false);
    }

    void Update() {
        messageTimer++;
        if (messageTimer > 120) {
            messageTimer = 0;
            setRewardInvisible();
        }
        checkForNewHighScore();
    }

    public static AchievementController getInstance() {
        if (scoreManager == null) {
            scoreManager = new AchievementController();
        }
        return scoreManager;
    }

    public int getScore() {
        return score;
    }

    public int setScore(int score) {
        this.score = score;
        return score;
    }

    public void newScoreRate(int score) {
        this.score += score;
    }

    public void setRewardVisible() {
        AwesomeImage.gameObject.SetActive(true);
        AwesomeImage.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, this.transform.position.z);
    }

    public void setRewardInvisible() {
        AwesomeImage.gameObject.SetActive(false);
    }

    public void checkForNewHighScore() {
        if (PlayerPrefs.GetInt("Score") <= 0) {
            PlayerPrefs.SetInt("Score", 0);
        }
        if (PlayerPrefs.GetInt("Score") < this.score) {
            PlayerPrefs.SetInt("Score", this.score);
        }
    }

    public int returnHighScore() {
        if (PlayerPrefs.GetInt("Score") <= 0) {
            return 0;
        } 
        return PlayerPrefs.GetInt("Score");
    }

    public void onReceiveMessageSetMessageVisible(Notification note) {
        setRewardVisible();
    }
}
