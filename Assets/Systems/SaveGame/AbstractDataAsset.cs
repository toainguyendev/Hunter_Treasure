using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public abstract class AbstractDataAsset<DataModel> : ScriptableObject where DataModel : struct
{
    [SerializeField] protected DataModel dataModel;

    [Space(12)]
    [SerializeField] private string fileName = string.Empty;
    [SerializeField] private bool binaryFormat = false;


    public void SaveData()
    {
        string filePath = Application.persistentDataPath + "/" +fileName;
        try
        {
            if (binaryFormat)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fileStream, dataModel);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(dataModel, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
        }catch (Exception e)
        {
            ConsoleLog.LogError($"Save Game Service: Error: {e}");
        }
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/" + fileName;

        try
        {
            if (!File.Exists(filePath))
            {
                SaveData();
            }
            else
            {
                if (binaryFormat)
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        dataModel = (DataModel)formatter.Deserialize(fileStream);
                    }
                }
                else
                {
                    string json = File.ReadAllText(filePath);
                    dataModel = JsonConvert.DeserializeObject<DataModel>(json);
                }
            }
        }
        catch (Exception e)
        {
            ConsoleLog.LogError($"Save Game Service: Error: {e}");
        }
    }
}
