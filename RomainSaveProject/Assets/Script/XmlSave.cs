using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using static UnityEngine.Rendering.DebugUI;
using System.Threading.Tasks;

public class XmlSave : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI countText;

    public string myName;
    bool isStarted;

    private void Start()
    {
        Debug.Log(Application.persistentDataPath.ToString());
        isStarted = true;
        LoadGame();
    }

    public void SaveTheGame()
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            NewLineOnAttributes = true,
            Indent = true,
        };

        XmlWriter writer = XmlWriter.Create("Assets" + "/save.xml", settings);
        writer.WriteStartDocument();

        writer.WriteStartElement("global");

        
        
        
        WriteXML(writer, "name", myName);
        
        WriteXML(writer, "timeFromStart", GetTime());
        
        WriteXML(writer, "buttonPress", GetComponent<ClickButtonCount>().count.ToString());




        



        writer.WriteEndElement();

        writer.WriteEndDocument();
        writer.Close();
    }

    public void LoadGame()
    {
        XmlDocument saveFile = new XmlDocument();

        if (!System.IO.File.Exists("Assets" + "/save.xml"))
        {
            Debug.LogError("Tu te fou de ma gueule fdp");
            return;
        }

        saveFile.Load("Assets" + "/save.xml");

        string key;
        string value;

        foreach (XmlNode node in saveFile.ChildNodes[1])
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
                    if (isStarted)
                    {
                        countText.text = value;
                        GetComponent<ClickButtonCount>().count = int.Parse(value);
                        isStarted = false;
                    }
                    else
                    {
                        countText.text = value;
                    }
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
