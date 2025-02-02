using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Label objectCounterLabel;
    private int totalObjects = 3;
    private int foundObjects = 0;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        objectCounterLabel = root.Q<Label>("ObjectCounter");
        UpdateObjectCounter();
    }

    public void ObjectFound()
    {
        foundObjects++;
        UpdateObjectCounter();

        if (foundObjects >= totalObjects)
        {
            Debug.Log("Уровень завершён!");
            SceneManager.LoadScene(0);
        }
    }

    private void UpdateObjectCounter()
    {
        objectCounterLabel.text = $"{foundObjects}/{totalObjects}";
    }
}
