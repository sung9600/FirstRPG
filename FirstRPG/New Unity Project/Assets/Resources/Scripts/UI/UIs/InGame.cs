using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGame : MonoBehaviour
{
    public static Transform HpIndicator;
    public static Transform CoinIndicator;
    public static Transform KeyIndicator;

    void Start()
    {
        HpIndicator = transform.Find("HpIndicator");
        CoinIndicator = transform.Find("CoinIndicator");
        KeyIndicator = transform.Find("KeyIndicator");
        ChangeCoin(UserStat.Instance._Coin);
        ChangeKey(UserStat.Instance._Key);
        ChangeHp(UserStat.Instance._currenthp / UserStat.Instance._hp);
    }

    public static void ChangeHp(float value)
    {
        //Debug.Log(HpIndicator.Find("ImageMask"));
        //Debug.Log(HpIndicator.Find("ImageMask").Find("Slider"));
        HpIndicator.Find("ImageMask").Find("Slider").GetComponent<Slider>().value = value;
        HpIndicator.Find("Text").GetComponent<TextMeshProUGUI>().text = $"{value * 100}%";
    }

    public static void ChangeCoin(int value)
    {
        CoinIndicator.Find("Text").GetComponent<TextMeshProUGUI>().text = $"x {value}";
    }

    public static void ChangeKey(int value)
    {
        KeyIndicator.Find("Text").GetComponent<TextMeshProUGUI>().text = $"x {value}";
    }
}
