using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHandle : MonoBehaviour {
    public Material[] Colors;
    int Score;
    public Text ScoreTxt;
    public GameObject Panel;
    public GameObject Enemy;
    public Vector3 StartingPos;
	// Use this for initialization
	void Start () {
        StartingPos = transform.position;
        ScoreTxt.text = Score.ToString();
        
        GetComponent<Renderer>().material = Colors[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (GetComponent<Renderer>().material.color == col.gameObject.GetComponent<Renderer>().material.color)
        {
        int num = Random.Range(0, 6);
        GetComponent<Renderer>().material = Colors[num];
        Score++;
            if (Score == 10)
            {
                Instantiate(this.gameObject, StartingPos, Quaternion.identity);
            }
        ScoreTxt.text = Score.ToString();
        }
        else
        {
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
