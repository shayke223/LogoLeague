using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
   
    public static void SavePlayer(GameManagerObject Player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/QuizSave.sav", FileMode.Create);

        PlayerData data = new PlayerData(Player);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static bool[,] LoadPlayerBools()
    {
        if (File.Exists(Application.persistentDataPath + "/QuizSave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/QuizSave.sav", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(stream);
            stream.Close();
            return data.StagesAndLevels;

        }
        return null;
    }
    public static int[,] LoadPlayerClues()
    {
        if (File.Exists(Application.persistentDataPath + "/QuizSave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/QuizSave.sav", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(stream);
            stream.Close();
            return data.SavedClues;

        }
        return null;
    }
    public static bool[] LoadPlayerBools1()
    {
        if (File.Exists(Application.persistentDataPath + "/QuizSave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/QuizSave.sav", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(stream);
            stream.Close();
            return data.AllStageRooms;

        }
        return null;
    }

    public static int[] LoadPlayerInts()
    {
        if (File.Exists(Application.persistentDataPath + "/QuizSave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/QuizSave.sav", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(stream);
            stream.Close();
            return data.AllCompletedLevels;
            
        }
        return null;
    }
    public static int[] LoadPlayerIntsNumbers()
    {
        if (File.Exists(Application.persistentDataPath + "/QuizSave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/QuizSave.sav", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(stream);
            stream.Close();
            return data.CashAndScore;

        }
        return null;
    }

    [Serializable]
    public class PlayerData
    {
        public int HowManyStages = 60;

        public bool[,] StagesAndLevels;
        public bool[] AllStageRooms;
        public int[] AllCompletedLevels;
        public int[] CashAndScore;
        public int[,] SavedClues;

        public PlayerData(GameManagerObject Player)
        {
            StagesAndLevels = new bool[HowManyStages, 20];
            for (int i = 0; i < HowManyStages; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    StagesAndLevels[i, j] = Player.Stages[i, j];
                   
                }
            }

            AllStageRooms = new bool[HowManyStages];
            for (int f = 0; f < HowManyStages; f++)
            {
                AllStageRooms[f] = Player.StageRoom[f];
            }


            AllCompletedLevels = new int[HowManyStages+1];
            for (int t = 0; t < HowManyStages; t++)
            {
                AllCompletedLevels[t] = Player.LevelComplete[t];
            }

            CashAndScore = new int[2];

            CashAndScore[0] = Player.Cash;
            CashAndScore[1] = Player.Spins;

            SavedClues = new int[HowManyStages, 20];

            for (int i = 0; i < HowManyStages; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    SavedClues[i, j] = Player.ClueCounters[i, j];

                }
            }
        }
           
    }
}
