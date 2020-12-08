using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public UnityEvent OnPauseEvent;
	public UnityEvent OnPlayEvent;
	public UnityEvent OnGameOverEvent;
	public UnityEvent OnResumeEvent;

	public delegate void OnCurrentScoreChanged(int score);
	public OnCurrentScoreChanged onCurrentScoreChanged;
	
	private const string KEY_HIGH_SCORE = "HIGH_SCORE";

	private static int highScore = 0;
	private static int lastScore = 0;
	private bool isGameEnded;

    public static int HighScore
    {
        get
        {
			if(PlayerPrefs.HasKey(KEY_HIGH_SCORE))
			{
				highScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE);
            	return highScore;
			} else {
				return 0;
			}
        }

        set
        {
			PlayerPrefs.SetInt(KEY_HIGH_SCORE, value);
            highScore = value;
        }
    }

    public static int LastScore
    {
        get
        {
			return lastScore;
        }

        set
        {
            lastScore = value;
			if(lastScore > highScore)
			{
				HighScore = lastScore;
			}
        }
    }

	void Awake()
	{
		instance = this;
		lastScore = 0;
	}
	public void Play()
	{
		isGameEnded = false;
		instance.OnPlayEvent.Invoke();
	}

	public void Pause()
	{
		Time.timeScale = 0;
		instance.OnPauseEvent.Invoke();
	}

	public void Retry()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
	
	public void GameOver()
	{
		if(!isGameEnded)
		{
			instance.OnGameOverEvent.Invoke();
			isGameEnded = true;
		}
	}

	public void Resume()
	{
		Time.timeScale = 1;
		instance.OnResumeEvent.Invoke();
	}

	public void AddScore(int value)
	{
		LastScore += value;

		if(onCurrentScoreChanged != null)
		{
			onCurrentScoreChanged.Invoke(lastScore);
		}
	}
}
