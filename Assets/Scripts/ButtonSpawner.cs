using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public Button buttonPrefab;
    public Transform contentTransform;

    void Start()
    {
        SpawnButton();
    }

    void SpawnButton()
    {
        Button newButton = Instantiate(buttonPrefab, contentTransform);
        newButton.onClick.AddListener(SpawnButton);
    }
}
