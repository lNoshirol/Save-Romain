using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using Unity.VisualScripting;

public class XmlSave : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI countText;

    public string myName;


    private void Start()
    {
        Debug.Log(Application.persistentDataPath.ToString());
        LoadGame();
    }

    public void SaveTheGame()
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            NewLineOnAttributes = true,
            Indent = true,
        };

        XmlWriter writer = XmlWriter.Create(Application.persistentDataPath + "/save.xml", settings);
        writer.WriteStartDocument();

        writer.WriteStartElement("global");

        
        
        
        WriteXML(writer, "name", myName);
        
        WriteXML(writer, "timeFromStart", GetTime());
        
        WriteXML(writer, "buttonPress", GetComponent<ClickButtonCount>().count.ToString());








        writer.WriteEndElement();

        writer.WriteEndDocument();
        writer.Close();

        LoadGame();
    }

    public void LoadGame()
    {
        XmlDocument saveFile = new XmlDocument();

        if (!System.IO.File.Exists(Application.persistentDataPath + "/save.xml"))
        {
            Debug.LogError("Tu te fou de ma gueule fdp");
            return;
        }

        saveFile.Load(System.IO.File.ReadAllText(Application.persistentDataPath + "/save.xml"));

        string key;
        string value;

        Debug.Log(saveFile.ChildNodes.Count);

        foreach (XmlNode node in saveFile.ChildNodes[0])
        {

            key = node.Name;
            value = node.InnerText;

            switch (key)
            {
                case "name":
                    nameText.text = value;
                    myName = value;
                    break;
                case "timeFromStart":
                    timeText.text = value;
                    break;
                case "buttonPress":
                    countText.text = value;
                    GetComponent<ClickButtonCount>().count = int.Parse(value);
                    break;
            }
        }
    }

    public void WriteXML(XmlWriter _writer, string key, string value)
    {
        _writer.WriteStartElement(key);
        _writer.WriteString(value);
        _writer.WriteEndElement();
    }

    public string GetTime()
    {
        return Time.time.ToString();
    }
}
