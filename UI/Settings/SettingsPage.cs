using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SettingsPage : MonoBehaviour
{
    public SettingsManager SettingsManager;
    public SettingsPageLine SettingsPageLine;
    public SettingsCategory Category;
    JObject _settingsOfCategory;
    public enum SettingsCategory
    {
        Gameplay,
        Audio,
        Mouse
    }

    void Start()
    {
        _settingsOfCategory = GetSettingsOfCategory();
        Fill();
    }

    public void Fill()
    {
        foreach (var line in _settingsOfCategory)
        {
            CreateFiller(line);
        }
    }

    void CreateFiller(KeyValuePair<string, JToken?> line)
    {
        SettingsPageLine filler = Instantiate(SettingsPageLine, transform);
        filler.KeyContainer.GetComponentInChildren<TextMeshProUGUI>().text = line.Key;
        filler.ValueContainer.SetValue(line.Value);
        filler.View.text = SettingsManager.Localization[line.Key].Value<string>();
        filler.SettingsPage = this;
        filler.SettingsManager = SettingsManager;
    }

    JObject GetSettingsOfCategory()
    {
        string settings = JsonUtility.ToJson(SettingsManager.Settings);
        JObject jObj = JObject.Parse(settings);
        JObject settingsOfCategory = jObj[Category.ToString()] as JObject;
        return settingsOfCategory;
    }
}