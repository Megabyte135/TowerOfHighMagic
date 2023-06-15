using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance = null;
    public Settings Settings { get; private set; }
    public JObject Localization { get; private set; }
    [SerializeField] bool ForceRecreateSettings = false;
    const string SettingsFileName = "Settings.json";
    const string LocalizationFileName = "SettingsLocalization.json";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        InitializeSettings();
        InitializeLocalization();
    }

    public void ChangeSetting(string key, object value)
    {
        FieldInfo[] fields = typeof(Settings).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            Type typeOfField = field.FieldType;
            FieldInfo[] fieldsOfField = typeOfField.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo item in fieldsOfField)
            {
                if (item.Name == key)
                {
                    item.SetValue(field.GetValue(Settings), value);
                    SaveChanges();
                }
            }
        }
    }

    void SaveChanges()
    {
        string settingsFilePath = Application.dataPath + "/" + SettingsFileName;
        string fileContent = JsonUtility.ToJson(Settings);
        File.WriteAllText(settingsFilePath, fileContent);
    }

    void InitializeSettings()
    {
        string settingsFilePath = Application.dataPath + "/" + SettingsFileName;
        bool fileExist = File.Exists(settingsFilePath);
        if (!fileExist || ForceRecreateSettings) {
            CreateSettings(settingsFilePath);
        }
        else
        {
            string fileContent = File.ReadAllText(settingsFilePath);
            Settings = JsonUtility.FromJson<Settings>(fileContent);
        }
    }

    void InitializeLocalization()
    {
        string localizationFilePath = Application.dataPath + "/" + LocalizationFileName;
        bool fileExist = File.Exists(localizationFilePath);
        if (!fileExist)
        {
            CreateLocalization(localizationFilePath);
        }
        else
        {
            Localization = JObject.Parse(File.ReadAllText(localizationFilePath));
        }
    }

    void CreateSettings(string path)
    {
        Settings = new Settings();
        string fileContent = JsonUtility.ToJson(Settings);
        File.WriteAllText(path, fileContent);
    }

    void CreateLocalization(string path)
    {
        JObject oldLocalization = JObject.Parse(JsonUtility.ToJson(Settings));
        JObject newLocalization = new JObject();
        foreach (JProperty property in oldLocalization.Properties())
        {
            JObject parameters = (JObject)property.Value;
            foreach (JProperty parameter in parameters.Properties())
            {
                newLocalization.Add(parameter.Name, parameter.Name);
            }
        }
        File.WriteAllText(path, newLocalization.ToString());
    }
}
