using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour {

    GameObject Main;
    GameObject Controls;
    GameObject Scores;

	// Use this for initialization
	void Start () {
        Main = GameObject.Find("Main");
        Controls = GameObject.Find("Controls");
        Scores = GameObject.Find("Scores");
        ToMain();
    }


    public void ToMain()
    {
        Main.SetActive(true);
        Controls.SetActive(false);
        Scores.SetActive(false);
    }

    public void ToControls()
    {
        Main.SetActive(false);
        Controls.SetActive(true);
        Scores.SetActive(false);
    }

    public void ToScores()
    {
        Main.SetActive(false);
        Controls.SetActive(false);
        Scores.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); 
    }
}
