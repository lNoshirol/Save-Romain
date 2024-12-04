using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickButtonCount : MonoBehaviour
{
    public int count = 0;

    public void OnClick()
    {
        count++;
    }
}
