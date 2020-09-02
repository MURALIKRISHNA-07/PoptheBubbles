using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    public GameObject Bubble1;
    public GameObject Bubble2;
    public GameObject Bubble3;

    public string[] words;
    public Text text1;
    public Text text2;
    public Text text3;

    //UI
    public GameObject start;
    public GameObject Game;
    public GameObject Pause;
    public GameObject Resume;
    public GameObject Gameover;

    public Text score;
    public Text highscore;

    public GameObject _Score;
    public GameObject _HighScore;

    //audio for CORRECT and GameOver
    public AudioSource rightanswer;
    public AudioSource gameover;

    public AudioManager instance;

    public int Score;
    public int Highscore;
    int add;
    int temp;
    int[] ran;
    
    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);

        words = new string[instance.sounds.Length];
        for (int i = 0; i < instance.sounds.Length; i++)
        {
            words[i] = instance.sounds[i].name;
        }
        ran = new int[3];

        if (PlayerPrefs.HasKey("HighScore"))
        {
            Highscore= PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetInt("HighScore", Highscore);
        }

        score.text = "SCORE:" + Score;
        highscore.text = "HIGH SCORE:" +
            "" + Highscore;
    }

    public void SelectWords()
    {
        //Activating Bubbles
        Bubble1.SetActive(true);
        Bubble2.SetActive(true);
        Bubble3.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0, words.Length);
            ran[i] = random;

        }

        checkrepeat(); 

        text1.text = ""+words[ran[0]];
        text2.text = ""+words[ran[1]];
        text3.text = ""+words[ran[2]];

        //choosing random between the three words
        int  Number= Random.Range(0, ran.Length);
        int n = ran[Number];
        //playing the sound
        instance.Play(n);
        //storing temporarily 
        temp = Number;

    }

    //WORDS NOT TO REPEAT FOR THE BUBBLE
    void checkrepeat()
    {
        if (ran[0] == ran[1])
        {
            int r = Random.Range(0, words.Length);
           // Debug.Log("RAN1---" + r);
            ran[1] = r;
            checkrepeat();

        }
        else if (ran[0] == ran[2])
        {
            int r = Random.Range(0, words.Length);
            //Debug.Log("RAN2---" + r);
            ran[2] = r;
            checkrepeat();

        }
        else if (ran[1] == ran[2])
        {
            int r = Random.Range(0, words.Length);
            //Debug.Log("RAN3---" + r);
            ran[2] = r;
            checkrepeat();

        }
        else
        {
            //Debug.Log("RAN----" + 0);

        }

    }

    //checking pressed bubble is right or wrong
    public void ButtonPress(int thisid)
    {
        switch (thisid)
        {
            case 0:
                Bubble1.SetActive(false);
                break;
            case 1:
                Bubble2.SetActive(false);
                break;
            case 2:
                Bubble3.SetActive(false);
                break;
            default: break;
        }

        if (temp==thisid)
        {
            //correct sound
            rightanswer.Play();
            Score++;
            //wait 
            //next word
            Invoke("SelectWords", 0.1f);
            Bubble1.SetActive(false);
            Bubble2.SetActive(false);
            Bubble3.SetActive(false);
        }
        else
        {
            //Wrong
            gameover.Play();
            //Game over
            GameOver();
        }
    }

    //START
    public void startgame()
    {
        Score = 0;
        start.SetActive(false);
        _HighScore.SetActive(false);
        _Score.SetActive(true);
        Gameover.SetActive(false);
        Game.SetActive(true);
        Pause.SetActive(true);
        SelectWords();
    }

    //PAUSE
    public void gamepause()
    {
        Time.timeScale = 0;
        Pause.SetActive(false);
        Resume.SetActive(true);
    }

    //RESUME
    public void resume()
    {
        Time.timeScale = 1.0f;
        Resume.SetActive(false);
        Pause.SetActive(true);
    }

    //GAMEOVER
    public void GameOver()
    {
        Gameover.SetActive(true);
        start.SetActive(false);
        Game.SetActive(false);
        Resume.SetActive(false);
        Pause.SetActive(false);
    }

    //BACK TO START
    public void backtostart()
    {
        start.SetActive(true);
        Time.timeScale = 1.0f;
        _HighScore.SetActive(true);
        _Score.SetActive(false);
        Gameover.SetActive(false);
        Game.SetActive(false);
        Pause.SetActive(false);
        Resume.SetActive(false);
    }

    //QUIT APPLICATION
    public void Quit()
    {
        Application.Quit();
    }
}
