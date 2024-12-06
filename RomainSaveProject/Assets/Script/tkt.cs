using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tkt : MonoBehaviour
{
    public XmlSave nameToChenge;

    private void Start()
    {
        Debug.Log(GetComponent<TMP_InputField>());

    }
    public void OnValueChange()
    {
        nameToChenge.myName = GetComponent<TMP_InputField>().text;
        nameToChenge.SaveTheGame();
    }

    public void OnEndEdit()
    {
        nameToChenge.myName = GetComponent<TMP_InputField>().text;
        nameToChenge.SaveTheGame();
    }

    public void OnSelect()
    {

    }

    public void OnDeselect()
    {

    }
}