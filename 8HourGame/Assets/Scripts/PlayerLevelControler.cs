using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLevelControler : MonoBehaviour {

    PlayerController player;
    public int currentExp;
    Text levText;
    float dispTime = 3;
    float turnoff;
    Slider helathSlider;

    int level;

	void Start () {
        helathSlider = GameObject.Find("HelathSlider").GetComponent<Slider>();
        levText = GameObject.Find("LevText").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentExp = 0;
        level = 1;
        levText.text = "";
    }
	
	void Update () {
        if(CheckLevl() == true)
        {
            levText.text = "Level Up. At Level: " + level.ToString();
        }

        if(Time.time >= turnoff)
        {
            levText.text = "";
        }
	}

    bool CheckLevl()
    {
        int tempLev = level;
        int baseint = 50;       //How much each level will increment by.
        double expCh = 10;      //Changing base change
        double Unused = 0;

        for (int lev = level; lev > 1; lev--)
        {
            expCh += baseint;
            Unused = expCh;
        }

        for (expCh = Unused; expCh + baseint <= currentExp; expCh += baseint)     //Extra EXP
        {
            tempLev++;
            if (tempLev % 3 == 0 || tempLev == 0)   // Level is 0 or Divisable by 3
            {
                player.maxhealth += 10;    //Increase Max Health by 10
                player.health = player.maxhealth;
                helathSlider.maxValue = player.maxhealth;
            }

            else if (tempLev % 3 == 1) //if level has a remainder of 1.
            {
                player.fireRate -= .1f;   //Increase Attack by 5
                if(player.fireRate < .1f)
                {
                    player.fireRate = .1f;
                }
            }

            else if (tempLev % 3 == 2)    //if Level has a remainder of 2
            {
                player.ammo += 1;    //Increase ammo by 1
            }
            level = tempLev;
            turnoff = dispTime + Time.time;
            return true;
        }

        return false;
    }
}
