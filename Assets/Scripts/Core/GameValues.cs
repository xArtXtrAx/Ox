using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for storing all game values/data
 */
public class GameValues : MonoBehaviour
{
    int _totalclicks = 0;
    int _clicksPerSecond = 0;
    
    int _clicksPerClick = 1;

    int _productionUpgrade1Level = 0;
    int _productionUpgrade2Level = 0;
    int _productionUpgrade3Level = 0;

    int[] _productionUpgradeLevel;

    int _cpsUpgrade1Level = 0;
    int _cpsUpgrade2Level = 0;
    int _cpsUpgrade3Level = 0;

    int[] _cpsUpgradeLevel;

    // MUTATORS

    public void UpdateTotalClicks()
    {
        _totalclicks += _clicksPerClick;
    }

    public void AddCPSToTotalClicks()
    {
        _totalclicks += _clicksPerSecond;
    } 

    public void IncreaseProdUpgrade1Level()
    {
        _productionUpgrade1Level++;
        _clicksPerClick++;
    }

    public void IncreaseProdUpgrade2Level()
    {
        _productionUpgrade2Level++;
        _clicksPerClick += 5;
    }

    public void IncreaseProdUpgrade3Level()
    {
        _productionUpgrade3Level++;
    }

    public void IncreaseCPSUpgrade1Level()
    {
        _cpsUpgrade1Level++;
        _clicksPerSecond++;
    }

    public void IncreaseCPSUpgrade2Level()
    {
        _cpsUpgrade2Level++;
        _clicksPerSecond += 5;
    }

    public void IncreaseCPSUpgrade3Level()
    {
        _cpsUpgrade3Level++;
    }

    // ACCESSORS

    public int GetTotalClicks()
    {
        return _totalclicks;
    }

    public int GetClicksPerClick()
    {
        return _clicksPerClick;
    }

    public int GetClicksPerSecond()
    {
        return _clicksPerSecond;
    }

    public int GetProdUpgrade1Level()
    {
        return _productionUpgrade1Level;
    }

    public int GetProdUpgrade2Level()
    {
        return _productionUpgrade2Level;
    }

    public int GetProdUpgrade3Level()
    {
        return _productionUpgrade3Level;
    }

    public int GetCPSUpgrade1Level()
    {
        return _cpsUpgrade1Level;
    }

    public int GetCPSUpgrade2Level()
    {
        return _cpsUpgrade2Level;
    }

    public int GetCPSUpgrade3Level()
    {
        return _cpsUpgrade3Level;
    }
}
