using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;

public class Saver : MonoBehaviour {
    InputField input;
    public List<int> scores;
    public List<string> names;

    // Use this for initialization
    void Start () {
        input = GameObject.Find("InputField").GetComponent<InputField>();	   
	}
	
	public void Save () {
        if(Environment.CurrentDirectory + "/SaveFile.xml" == null)
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

        }
        
    }
}
