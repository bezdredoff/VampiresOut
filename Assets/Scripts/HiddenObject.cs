using UnityEngine;

public class HiddenObject : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Автоматически ищем GameManager в сцене
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager не найден в сцене!");
        }
    }

    private void OnMouseDown()
    {
        if (gameManager != null)
        {
            gameManager.ObjectFound(); // Уведомляем GameManager
            gameObject.SetActive(false); // Скрываем объект
        }
        else
        {
            Debug.LogError("GameManager не привязан к HiddenObject.");
        }
    }
}
