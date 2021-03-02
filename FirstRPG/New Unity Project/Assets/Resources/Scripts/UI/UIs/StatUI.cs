using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    public static Button[] _buttons; // Atk Spd Hp 순
    public static Slider[] _sliders;
    [SerializeField]
    public static TextMeshProUGUI[] _costText;
    [SerializeField]
    public static TextMeshProUGUI[] _statText;
    // Start is called before the first frame update
    void Start()
    {
        _buttons = new Button[3];
        _buttons[0] = transform.Find("Atk").transform.Find("AtkUpButton").GetComponent<Button>();
        _buttons[1] = transform.Find("Spd").transform.Find("SpdUpButton").GetComponent<Button>();
        _buttons[2] = transform.Find("Hp").transform.Find("HpUpButton").GetComponent<Button>();


        _sliders = new Slider[3];
        _sliders[0] = transform.Find("Atk").GetComponent<Slider>();
        _sliders[1] = transform.Find("Spd").GetComponent<Slider>();
        _sliders[2] = transform.Find("Hp").GetComponent<Slider>();
        _sliders[0].value = 1;
        _sliders[1].value = 1;
        _sliders[2].value = 1;

        _costText = new TextMeshProUGUI[3];
        _costText[0] = transform.Find("Atk").transform.Find("AtkUpCost").GetComponent<TextMeshProUGUI>();
        _costText[1] = transform.Find("Spd").transform.Find("SpdUpCost").GetComponent<TextMeshProUGUI>();
        _costText[2] = transform.Find("Hp").transform.Find("HpUpCost").GetComponent<TextMeshProUGUI>();

        _costText[0].text = $" x 1";
        _costText[1].text = $" x 1";
        _costText[2].text = $" x 1";

        _statText = new TextMeshProUGUI[3];
        _statText[0] = transform.Find("Atk").transform.Find("AtkText").GetComponent<TextMeshProUGUI>();
        _statText[1] = transform.Find("Spd").transform.Find("SpdText").GetComponent<TextMeshProUGUI>();
        _statText[2] = transform.Find("Hp").transform.Find("HpText").GetComponent<TextMeshProUGUI>();

        _statText[0].text = "abc";

        _buttons[0].onClick.AddListener(UserStat.Instance.atkup);
        _buttons[1].onClick.AddListener(UserStat.Instance.spdup);
        _buttons[2].onClick.AddListener(UserStat.Instance.hpup);
    }
}
