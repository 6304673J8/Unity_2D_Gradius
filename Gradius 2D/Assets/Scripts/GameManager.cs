using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0;
    public int hitScore = 0;
    public int toLoadHighscore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Debug.Log("WARNING: multiple " + this + " in scene!");
        }
    }

    public void BinarySaver()
    {
        BinaryWriter writer = new BinaryWriter(File.Open("Highscore.sav", FileMode.Create));
        score = score - hitScore;
        writer.Write(score);
        writer.Close();

        BinaryReader reader;
        if (File.Exists("Highscore.sav"))
        {
            reader = new BinaryReader(File.Open("Highscore.sav", FileMode.Open));
        }
        else
        {
            return;
        }
        toLoadHighscore = reader.ReadInt32();
        reader.Close();
    }
}
