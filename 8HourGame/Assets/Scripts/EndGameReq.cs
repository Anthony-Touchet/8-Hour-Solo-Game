using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;

public class EndGameReq : MonoBehaviour, IEnumerable {

    GameObject player;
    public List<int> scores;
    public List<string> names;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.GetComponent<PlayerController>().health <= 0 || player.gameObject == null)
        {
            //Save();
            SceneManager.LoadScene("StartMenu");
        }
	}

    public void Save()
    {
        if (Environment.CurrentDirectory + "/SaveFile.xml" == null)
        {
            var goodpath = Environment.CurrentDirectory + "/SaveFile.xml";
            FileStream SaveFile = File.Create(goodpath);

            XmlSerializer serial = new XmlSerializer(typeof(Saver));
            serial.Serialize(SaveFile, this);
            SaveFile.Close();
        }

        else
        {
            XmlSerializer reader = new XmlSerializer(typeof(Saver));
            List<int> score = new List<int>();
            StreamReader File = new StreamReader(Environment.CurrentDirectory + "/SaveFile.xml");
            score = (List<int>)reader.Deserialize(File);

            scores = score;

            scores.Add(player.GetComponent<PlayerLevelControler>().currentExp);
        }

    }

    public IEnumerator GetEnumerator()
    {

        return ((IEnumerable)scores).GetEnumerator();
    }
}
