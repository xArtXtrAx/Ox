using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerGameController : MonoBehaviour
{
    public Button mainButton;
    public TextMeshProUGUI clickCounterText;
    public ScrollRect leftScrollView;
    public ScrollRect rightScrollView;

    public Button leftButtonPrefab;
    public Button rightButtonPrefab;

    private int clickCounter = 0;

    void Start()
    {
        mainButton.onClick.AddListener(IncrementClickCounter);
    }

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
    }

    void SpawnRightButton()
    {
        Button newButton = Instantiate(rightButtonPrefab, rightScrollView.content);
        RectTransform rt = newButton.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 1);
        rt.anchorMax = new Vector2(0.5f, 1);
        rt.pivot = new Vector2(0.5f, 1);
        rt.anchoredPosition = new Vector2(0, -rightScrollView.content.childCount * rt.sizeDelta.y);
    }
}
