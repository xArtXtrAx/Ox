using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    public RectTransform content;
    public float buttonHeight;
    public float buttonSpacing;
    private List<GameObject> buttons = new List<GameObject>();

    public void SpawnButton()
    {
        GameObject newButton = Instantiate(buttonPrefab, content);
        buttons.Add(newButton);

        RectTransform rectTransform = newButton.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -buttons.Count * (buttonHeight + buttonSpacing));
    }

    public void RemoveButtons()
    {
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }
}