//------------------------------------------------------------------------------
//
// File Name:	ScoreText.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that changes a TextMeshPro
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI MyTMP;

    // Start is called before the first frame update
    void Start()
    {
        MyTMP = GetComponent<TextMeshProUGUI>();

        //update text then add listen
        UpdateText();
        GameManager.OnVariablesUpdate.AddListener(UpdateText);
    }

    //set the text
    void UpdateText()
    {
        MyTMP.text = "Score: " + GameManager.Score.ToString("N0");
    }

    //remove listener when destroyed
    void OnDestory()
    {
        GameManager.OnVariablesUpdate.RemoveListener(UpdateText);
    }
}
