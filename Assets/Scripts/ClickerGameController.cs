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

    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public int colorSteps = 20;
    private Color[] colors = new Color[]
        {
        Color.red,
        new Color(1, 0.5f, 0),
        Color.yellow,
        Color.green,
        Color.blue,
        new Color(0.5f, 0, 1),
        Color.red
        };

    public Button leftButtonPrefab;
    public Button rightButtonPrefab;

    public float clicksPerSecond = 0f;
    public int clicksPerClick = 1;
    public int leftUpgradeFactor = 1;
    public int rightUpgradeFactor = 1;
    private int clickCounter = 0;

    public Material glowingMaterial;
    public float glowDuration = 10f;
    public float glowIntensity = 5f;

    private float elapsedTime = 0f;

    private float clicksAccumulator = 0f;

    private int rightButtonsSpawned = 0;
    private int leftButtonsSpawned = 0;


    void Start()
    {
        mainButton.onClick.AddListener(() => IncrementClickCounter(clicksPerClick));
        StartCoroutine(ClicksPerSecondUpdate());
        UpdateClicksPerClickDisplay();
        UpdateClicksPerSecondCounter();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float glow = Mathf.PingPong(elapsedTime / glowDuration, 1f) * glowIntensity;
        glowingMaterial.SetColor("_EmissionColor", Color.white * glow);
    }

    IEnumerator ClicksPerSecondUpdate()
    {
        while (true)
        {
            if (clicksPerSecond > 0)
            {
                clicksAccumulator += clicksPerSecond * Time.deltaTime;
                int clicksToAdd = Mathf.FloorToInt(clicksAccumulator);
                clicksAccumulator -= clicksToAdd;
                IncrementClickCounter(clicksToAdd);
            }
            yield return null;
        }
    }

    public int GetClickCounter()
    {
        return clickCounter;
    }

    public void ModifyCPSMultiplier(float multiplier)
    {
        clicksPerSecond *= multiplier;
        UpdateClicksPerSecondCounter();
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
            if (clickCounter % 10 == 0)
            {
                SpawnLeftButton();
                leftUpgradeFactor++;
            }

            if (clickCounter % 10 == 0)
            {
                SpawnRightButton();
                rightUpgradeFactor++;
            }
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
        int upgradeAmount = leftUpgradeFactor;
        newButton.onClick.AddListener(() => { clicksPerClick += upgradeAmount; UpdateClicksPerClickDisplay(); });
        
        // Update the button text and image
        TextMeshProUGUI upgradeAmountText = newButton.GetComponentInChildren<TextMeshProUGUI>();
        upgradeAmountText.text = $"Upgrade Clicks by {upgradeAmount}";

        Image upgradeLevelImage = newButton.transform.Find("UpgradeLevelImage").GetComponent<Image>();
        upgradeLevelImage.sprite = Resources.Load<Sprite>($"UpgradeIcons/Icon{leftUpgradeFactor}");

        TextMeshProUGUI upgradeLevelText = newButton.transform.Find("UpgradeLevelText").GetComponent<TextMeshProUGUI>();
        upgradeLevelText.text = leftUpgradeFactor.ToString();

        // Update the button color
        Color buttonColor = ColorLerp(0f, 1f, (float)leftButtonsSpawned / colorSteps);
        newButton.GetComponent<Image>().color = buttonColor;

        leftButtonsSpawned++;
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

        // Update the button text and image
        TextMeshProUGUI upgradeAmountText = newButton.GetComponentInChildren<TextMeshProUGUI>();
        upgradeAmountText.text = $"Upgrade CPS by {upgradeAmount}";

        Image upgradeLevelImage = newButton.transform.Find("UpgradeLevelImage").GetComponent<Image>();
        upgradeLevelImage.sprite = Resources.Load<Sprite>($"UpgradeIcons/Icon{rightUpgradeFactor}");

        TextMeshProUGUI upgradeLevelText = newButton.transform.Find("UpgradeLevelText").GetComponent<TextMeshProUGUI>();
        upgradeLevelText.text = rightUpgradeFactor.ToString();

        // Update the button color
        Color buttonColor = ColorLerp(0f, 1f, (float)rightButtonsSpawned / colorSteps);

        newButton.GetComponent<Image>().color = buttonColor;

        rightButtonsSpawned++;
    }

    Color ColorLerp(float start, float end, float t)
    {
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta };
        int numColors = colors.Length;

        float range = end - start;
        float adjustedT = (t * range + start) * numColors;

        int index = Mathf.FloorToInt(adjustedT) % numColors;
        float lerpFactor = adjustedT - Mathf.Floor(adjustedT);

        return Color.Lerp(colors[index], colors[(index + 1) % numColors], lerpFactor);
    }
}

