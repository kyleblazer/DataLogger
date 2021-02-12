using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public string filepath = "file.txt";
    // Start is called before the first frame update
    void Start()
    {
        MakeFile();
        EditFile("Game has started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            EditFile("Spacebar has been pressed");
        }
    }

    private void OnApplicationQuit()
    {
        EditFile("Game has ended");
    }
    private void MakeFile()
    {
        if (!File.Exists(filepath))
        {
            File.Create(filepath).Close();
        }
    }
    
    public void EditFile(string stringMessage)
    {
        using (StreamWriter writer = new StreamWriter(filepath, true))
        {
            writer.Write(DateTime.Now);
            writer.WriteLine(": "+stringMessage);
        }
    }

}
