using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carryover : MonoBehaviour {

    public Canvas myCanvas;

    public Text myText;
    
    public static int yourscore;

    static private carryover myPlayer;

    public static carryover getPlayer()
    {

        return myPlayer;

    }

    public void thescore(int score)
    {
        yourscore = score + 10;
    }

    public int getScore()
    {
        return yourscore;
    }

    void Awake()
    {
        /*if (myPlayer == null)
        {
            myPlayer = this;
        }
        else if (myPlayer != null)
        {
            Destroy(gameObject);
        }*/
        if (SceneManager.GetActiveScene().name == "victory")
        {
            DontDestroyOnLoad(transform.gameObject);
            myText.text = "Your score is: " + getScore();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //myText.text = "Your score is: " + getScore();
    }
}
