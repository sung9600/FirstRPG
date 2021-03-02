using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCube : Cube
{
    private void Awake()
    {
        camnum = 2;
    }
    public override void ShowUI()
    {
        // 2. UI 켜기

        UI_Popup questUI = GameManager.UI.ShowPopupUI<UI_Popup>("Stat");
    }
}
