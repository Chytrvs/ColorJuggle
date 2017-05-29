using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHandle : MonoBehaviour {
    [SerializeField]
     Material[] Colors;
    [SerializeField]
    Text ScoreTxt,LevelTxt,EndScoreTxt,BestScoreTxt;
    [SerializeField]
    GameObject Panel,Enemy;
    Vector3 StartingPos;
    int Score,Level;
	// Use this for initialization
	void Start () {
        StartingPos = transform.position;
        ScoreTxt.text =Score.ToString();
        LevelTxt.text = "Level: " + Level.ToString();
        GetComponent<Renderer>().material = Colors[(int)ColorsEnum.Gray];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    enum ColorsEnum
    {
        Green,Gray,Blue,Yellow,Red,Purple,EnumLenght
            
    }
    void OnTriggerEnter(Collider col)
    {
        if (GetComponent<Renderer>().material.color == col.gameObject.GetComponent<Renderer>().material.color)
        {
        int num = Random.Range(0, (int)ColorsEnum.EnumLenght);
        GetComponent<Renderer>().material = Colors[num];
        Score++;
            if (Score%10==0)
            {
                Time.timeScale = Time.timeScale + 0.1f;
                Level++;
                LevelTxt.text = "Level: " + Level.ToString();
            }
        ScoreTxt.text = Score.ToString();
        
        }
        else
        {
            EndScoreTxt.text = "Score: "+Score.ToString();
            if (Score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
            BestScoreTxt.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
            Score = 0;
            ScoreTxt.text = Score.ToString();
            Panel.SetActive(true);
            Time.timeScale = 0;
            
        }

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Application.LoadLevel(0);
        Time.timeScale = 2;
    }
}
