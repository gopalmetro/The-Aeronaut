using UnityEngine;
using System.Collections;

public class AchievementController : MonoBehaviour {

    public Texture2D image = null;

    private static AchievementController scoreManager = null;
    private int score = 0;
    private int messageTimer;
    private bool messageIsVisible;

    void Start() {
        DontDestroyOnLoad(this);
        messageTimer = 0;
        NotificationCenter.defaultCenter.addListener(onReceiveMessageSetMessageVisible, NotificationType.OnAchievableEvent);
    }

    void Update() {
        messageTimer++;
        if (messageTimer > 120) {
            messageTimer = 0;
            setMessageInvisible();
        }
        checkForNewHighScore();
    }

    public static AchievementController getInstance() {
        if (scoreManager == null) {
            scoreManager = new AchievementController();
        }
        return scoreManager;
    }

    void OnGUI() {
        if (messageIsVisible) {
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), image);
        }
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

    public void setMessageVisible() {
        messageIsVisible = true;
    }

    public void setMessageInvisible() {
        messageIsVisible = false;
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

    public void onReceiveMessageSetMessageVisible(Notification note)
    {
        setMessageVisible();
    }

}
