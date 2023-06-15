using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SettingsPage : MonoBehaviour
{
    public SettingsPageLine SettingsPageLine;
    public SettingsCategory Category;
    SettingsManager _settingsManager;
    JObject _settingsOfCategory;
    public enum SettingsCategory
    {
        Gameplay,
        Audio,
        Mouse
    }

    void Start()
    {
        _settingsManager = SettingsManager.instance;
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
        filler.View.text = _settingsManager.Localization[line.Key].Value<string>();
        filler.SettingsPage = this;
        filler.SettingsManager = _settingsManager;
    }

    JObject GetSettingsOfCategory()
    {
        string settings = JsonUtility.ToJson(_settingsManager.Settings);
        JObject jObj = JObject.Parse(settings);
        JObject settingsOfCategory = jObj[Category.ToString()] as JObject;
        return settingsOfCategory;
    }
}