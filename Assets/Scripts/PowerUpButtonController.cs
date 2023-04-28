using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButtonController : MonoBehaviour
{
    public Button powerUpButton;
    public ClickerGameController clickerGameController;

    private int currentPower = 1;

    private void Start()
    {
        powerUpButton.onClick.AddListener(PowerUpCPS);
        powerUpButton.interactable = false;
    }

    private void Update()
    {
        int targetClicks = (int)Mathf.Pow(10, currentPower);
        if (clickerGameController.GetClickCounter() >= targetClicks)
        {
            powerUpButton.interactable = true;
        }
        else
        {
            powerUpButton.interactable = false;
        }
    }

    private void PowerUpCPS()
    {
        clickerGameController.ModifyCPSMultiplier(4);
        currentPower++;
    }
}
