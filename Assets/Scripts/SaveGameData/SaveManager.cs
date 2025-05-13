using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public void LoadData()
    {
        if(File.ReadAllText(Application.dataPath + "/saveData.json") != null)
        {
            string json = File.ReadAllText(Application.dataPath + "/saveData.json");

            ResultCollection jsonData = JsonUtility.FromJson<ResultCollection>(json);

            ResultCollection.Stage1Star = jsonData._Stage1Star;
            ResultCollection.Stage2Star = jsonData._Stage2Star;
            ResultCollection.Stage3Star = jsonData._Stage3Star;

            ResultCollection.Stage2Unlocked = jsonData._Stage2Unlocked;
            ResultCollection.Stage3Unlocked = jsonData._Stage3Unlocked;
        }
        else
        {
            SaveData();
        }
    }

    public void SaveData()
    {
        ResultCollection data = new ResultCollection();
        ProgressData saveData = new ProgressData();

        data._Stage1Star = saveData.Stage1Star;
        data._Stage2Star = saveData.Stage2Star;
        data._Stage3Star = saveData.Stage3Star;


        data._Stage2Unlocked = saveData.Stage2Unlocked;
        data._Stage3Unlocked = saveData.Stage3Unlocked;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath+ "/saveData.json", json);
    }
}
