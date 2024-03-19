using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    
    public bool startPlaying;
    
    public BeatScroller theBS;
    
    public static GameManager instance;

	public int currentScore;
	public int scorePerNote = 100;
	public int scorePerGoodNote = 125;
	public int scorePerPerfectNote = 150;


	public Text scoreText;
	public Text multiText;

	public float totalNotes;
	public float normalHits;
	public float goodHits;
	public float perfectHits;
	public float missedHits;

	public GameObject resultsScreen;
	public Text percentHitText, oksText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

		Cursor.lockState = CursorLockMode.Locked;

		scoreText.text = " ";
		totalNotes = FindObjectsOfType<NoteObject>().Length;
		//Finding how many objects have the NoteObject Script attatched to them so we can predict how many (type)hits players get
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseManager.isPaused)
        {

        
				if(!startPlaying)
				{
					if(Input.anyKeyDown)
					{
						startPlaying = true; 
						theBS.hasStarted = true;

						theMusic.Play();
					}
				}else
				{
					if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
					{
						resultsScreen.SetActive(true);

						//Showing updated values on screen - strings are text
						oksText.text = "" + normalHits;
						goodsText.text = goodHits.ToString();
						perfectsText.text = perfectHits.ToString();
						missesText.text = missedHits.ToString();

						//Working out percentage of hits

						float totalHit = normalHits + goodHits + perfectHits;
						float percentHit = (totalHit / totalNotes) * 100f;

						percentHitText.text = percentHit.ToString("F1") + "%";
						//F1 is a shortcut in unity that which tells program to show this as a float value with 1 decimal place. 

						string rankVal = "F";

						if(percentHit > 40)
						{
							rankVal = "D";
							if(percentHit > 55)
							{
								rankVal = "C";
								if(percentHit > 70)
								{
									rankVal = "B";
									if(percentHit > 85)
									{
										rankVal = "A";
										if (percentHit > 95)
										{
											rankVal = "S";
											if (percentHit >98.5)
											{
												rankVal = "SS";
											}
										}
									}
								}
							}
						}

						rankText.text = rankVal;

						finalScoreText.text = currentScore.ToString();
					}
			    }
		}
    }

	public void NoteHit()
	{
		Debug.Log("Hit On Time");

		//currentScore += scorePerNote;
		scoreText.text = " " + currentScore;
	}

	public void NormalHit()
    {
		currentScore += scorePerNote;
		NoteHit();

		normalHits++;
    }

	public void GoodHit()
    {
		currentScore += scorePerGoodNote;
		NoteHit();

		goodHits++;
    }

	public void PerfectHit()
    {
		currentScore += scorePerPerfectNote;
		NoteHit();

		perfectHits++;
    }

	public void NoteMissed()
	{
		Debug.Log("Missed Note");

		missedHits++;
	}

	public void ResultsWin()
    {
        SceneManager.LoadScene("STYD2");
    }
}
