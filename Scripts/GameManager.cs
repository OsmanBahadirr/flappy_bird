using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    private Player player;
    private Spawner spawner;

    public Text scoreText;
    public Text highScoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject soundButton;
    public Text slash;
    public Text highScoreLogo;

    private int score;
    private int highScore;
    public bool sound;    

    public void Awake(){
        Application.targetFrameRate =60;
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        Pause();
        gameOver.SetActive(false);
        sound = true;
        slash.enabled = false;
        highScore = 0;
        highScoreText.enabled = true;
        highScoreLogo.enabled = true;
    }

    public void Play(){
        score = 0;
        scoreText.text = score.ToString();
        
        playButton.SetActive(false);
        gameOver.SetActive(false);
        soundButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i=0; i< pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }
        highScoreText.enabled = false;
        highScoreLogo.enabled = false;
    }

    public void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;
        highScoreText.enabled = true;
        highScoreLogo.enabled = true;
        
    }
    public void GameOver(){
        playButton.SetActive(true);
        gameOver.SetActive(true);
        soundButton.SetActive(true);
        if(score> highScore){
            highScore = score;
            highScoreText.text = highScore.ToString();
        }
        Pause();

        
    }
 
    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
        Debug.Log("Deneme");
    }

     public void SoundSetting(){
        if(sound){
            sound = false;
            slash.enabled = true;
        }else if(!sound){
            sound = true;
            slash.enabled = false;
        }
    }

}
