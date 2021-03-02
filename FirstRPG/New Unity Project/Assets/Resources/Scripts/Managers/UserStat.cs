using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStat : MonoBehaviour
{
    public int _atk;
    public float _atkspeed;
    public int _hp;
    public int _currenthp;
    public int[] _upCost = new int[3]; //atk spd hp 순
    public int _Coin = 0;
    public int _Key = 1;

    public static UserStat instance = null;

    public static UserStat Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Instance._Coin = 0;
        Instance._atk = 50;
        Instance._atkspeed = 1.0f;
        Instance._hp = 100;
        Instance._currenthp = Instance._hp;
        for (int i = 0; i < 3; i++)
        {
            _upCost[i] = 1;
        }
    }


    public void atkup()
    {
        if (_upCost[0] <= _Coin)
        {
            _Coin -= _upCost[0];
            Debug.Log("AtkUp");
            UserStat.Instance._atk += 10;
            StatUI._sliders[0].value++;
            _upCost[0]++;
            StatUI._costText[0].text = $" x {_upCost[0]}";
        }
        else
        {
            showlackUI();
        }
    }
    public void spdup()
    {
        if (_upCost[1] <= _Coin)
        {
            _Coin -= _upCost[1];
            Debug.Log("SpdUp");
            UserStat.Instance._atkspeed += 0.25f;
            StatUI._sliders[1].value++;
            _upCost[1]++;
            StatUI._costText[1].text = $" x {_upCost[1]}";
        }
        else
        {
            showlackUI();
        }
    }
    public void hpup()
    {
        if (_upCost[0] <= _Coin)
        {
            _Coin -= _upCost[2];
            Debug.Log("HpUp");
            UserStat.Instance._hp += 25;
            StatUI._sliders[2].value++;
            _upCost[2]++;
            StatUI._costText[2].text = $" x {_upCost[2]}";
        }
        else
        {
            showlackUI();
        }
    }

    public void showlackUI()
    {
        UI_Popup MoneyLackUI = GameManager.UI.ShowPopupUI<UI_Popup>("LackUI");
        Destroy(MoneyLackUI.gameObject, 0.5f);
    }
}
