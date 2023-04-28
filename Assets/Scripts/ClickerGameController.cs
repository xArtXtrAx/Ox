using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerGameController : MonoBehaviour
{
    public Button mainButton;
    public TextMeshProUGUI clickCounterText;
    public TextMeshProUGUI clicksPerSecondCounterText;
    public TextMeshProUGUI clicksPerClickDisplayText;
    public ScrollRect leftScrollView;
    public ScrollRect rightScrollView;

    public Button leftButtonPrefab;
    public Button rightButtonPrefab;

    public float clicksPerSecond = 0f;
    public int clicksPerClick = 1;
    public int leftUpgradeFactor = 1;
    public int rightUpgradeFactor = 1;
    private int clickCounter = 0;

    void Start()
    {
        mainButton.onClick.AddListener(IncrementClickCounter);
        StartCoroutine(ClicksPerSecondUpdate());
        UpdateClicksPerClickDisplay();
        UpdateClicksPerSecondCounter();
    }

    IEnumerator ClicksPerSecondUpdate()
    {
        while (true)
        {
            IncrementClickCounter((int)clicksPerSecond);
            yield return new WaitForSeconds(1f);
        }
    }

    void UpdateClicksPerClickDisplay()
    {
        clicksPerClickDisplayText.text = $"Clicks per Click: {clicksPerClick}";
    }

    void UpdateClicksPerSecondCounter()
    {
        clicksPerSecondCounterText.text = $"Clicks per Second: {clicksPerSecond}";
    }


    void IncrementClickCounter(int incrementAmount)
    {
        clickCounter += incrementAmount;
        UpdateClickCounterText();

        if (incrementAmount == clicksPerClick)
        {
            if (clickCounter % 100 == 0)
            {
                SpawnLeftButton();
                leftUpgradeFactor++;
            }

            if (clickCounter % 1000 == 0)
            {
                SpawnRightButton();
                rightUpgradeFactor++;
            }
        }
    }


    /*

    void IncrementClickCounter()
    {
        clickCounter++;
        UpdateClickCounterText();

        if (clickCounter % 10 == 0)
        {
            SpawnLeftButton();
        }

        if (clickCounter % 100 == 0)
        {
            SpawnRightButton();
        }
    }

    */

    void UpdateClickCounterText()
    {
        clickCounterText.text = $"Clicks: {clickCounter}";
    }

    void SpawnLeftButton()
    {
        Button newButton = Instantiate(leftButtonPrefab, leftScrollView.content);
        RectTransform rt = newButton.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 1);
        rt.anchorMax = new Vector2(0.5f, 1);
        rt.pivot = new Vector2(0.5f, 1);
        rt.anchoredPosition = new Vector2(0, -leftScrollView.content.childCount * rt.sizeDelta.y);
        int upgradeAmount = leftUpgradeFactor;
        newButton.onClick.AddListener(() => { clicksPerClick += upgradeAmount; UpdateClicksPerClickDisplay(); });
    }

    void SpawnRightButton()
    {
        Button newButton = Instantiate(rightButtonPrefab, rightScrollView.content);
        RectTransform rt = newButton.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 1);
        rt.anchorMax = new Vector2(0.5f, 1);
        rt.pivot = new Vector2(0.5f, 1);
        rt.anchoredPosition = new Vector2(0, -rightScrollView.content.childCount * rt.sizeDelta.y);
        float upgradeAmount = rightUpgradeFactor;
        newButton.onClick.AddListener(() => { clicksPerSecond += upgradeAmount; UpdateClicksPerSecondCounter(); });
    }
}
