using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickManager : MonoBehaviour
{
    [SerializeField] GameValues _gameValues;

    [SerializeField] TextMeshProUGUI _totalClicks;
    [SerializeField] TextMeshProUGUI _clicksPerSecond;
    [SerializeField] TextMeshProUGUI _clickButtonFooter;
    [SerializeField] TextMeshProUGUI _upgrade1Footer;
    [SerializeField] TextMeshProUGUI _upgrade2Footer;
    [SerializeField] TextMeshProUGUI _upgrade3Footer;
    [SerializeField] TextMeshProUGUI _cps1Footer;
    [SerializeField] TextMeshProUGUI _cps2Footer;
    [SerializeField] TextMeshProUGUI _cps3Footer;

    float _timer = 0f;
    float _interval = 1f;

    void Update()
    {
        _timer += Time.deltaTime;

        if ( _timer >= _interval)
        {
            _gameValues.AddCPSToTotalClicks();
            _totalClicks.text = "" + _gameValues.GetTotalClicks();
            _timer = 0f;
        }
    }

    public void Click()
    {
        _gameValues.UpdateTotalClicks();
        _totalClicks.text = _gameValues.GetTotalClicks().ToString();
    }

    public void ClickUpgrade1()
    {
        _gameValues.IncreaseProdUpgrade1Level();
        _upgrade1Footer.text = "Level " + _gameValues.GetProdUpgrade1Level();
        _clickButtonFooter.text = "+" + _gameValues.GetClicksPerClick();
    }

    public void ClickUpgrade2()
    {
        _gameValues.IncreaseProdUpgrade2Level();
        _upgrade2Footer.text = "Level " + _gameValues.GetProdUpgrade2Level();
        _clickButtonFooter.text = "+" + _gameValues.GetClicksPerClick();
    }

    public void CPSUpgrade1()
    {
        _gameValues.IncreaseCPSUpgrade1Level();
        _cps1Footer.text = "Level " + _gameValues.GetCPSUpgrade1Level();
        _clicksPerSecond.text = _gameValues.GetClicksPerSecond() + " cps";
    }

    public void CPSUpgrade2()
    {
        _gameValues.IncreaseCPSUpgrade2Level();
        _cps2Footer.text = "Level " + _gameValues.GetCPSUpgrade2Level();
        _clicksPerSecond.text = _gameValues.GetClicksPerSecond() + " cps";
    }
}
