using UnityEngine;

public class ScrollAndZoom : MonoBehaviour
{
    public Camera mainCamera; // Камера, которая скроллит и зумит
    public SpriteRenderer backgroundSprite; // Объект с изображением фона

    public float zoomSpeed = 0.5f; // Скорость зума
    public float minZoom = 5f; // Минимальное приближение
    public float maxZoom = 15f; // Максимальное приближение

    private Vector3 dragOrigin; // Точка начала скролла
    private float backgroundMinX, backgroundMaxX, backgroundMinY, backgroundMaxY; // Границы фона

    private void Start()
    {
        if (backgroundSprite != null)
        {
            // Вычисляем границы фона
            Vector2 spriteSize = backgroundSprite.bounds.size;
            Vector3 spritePosition = backgroundSprite.transform.position;

            backgroundMinX = spritePosition.x - spriteSize.x / 2f;
            backgroundMaxX = spritePosition.x + spriteSize.x / 2f;
            backgroundMinY = spritePosition.y - spriteSize.y / 2f;
            backgroundMaxY = spritePosition.y + spriteSize.y / 2f;
        }
    }

    private void Update()
    {
        HandleScroll();
        HandleZoom();
    }

    private void HandleScroll()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = mainCamera.transform.position + difference;

            // Ограничиваем позицию камеры границами фона
            newPosition.x = Mathf.Clamp(newPosition.x, backgroundMinX + mainCamera.orthographicSize * mainCamera.aspect, backgroundMaxX - mainCamera.orthographicSize * mainCamera.aspect);
            newPosition.y = Mathf.Clamp(newPosition.y, backgroundMinY + mainCamera.orthographicSize, backgroundMaxY - mainCamera.orthographicSize);

            mainCamera.transform.position = newPosition;
        }
    }

    private void HandleZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            float prevMagnitude = (touchZero.position - touchOne.position).magnitude;
            float currMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currMagnitude - prevMagnitude;

            // Меняем поле зрения камеры
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - difference * zoomSpeed, minZoom, maxZoom);
        }
        else if (Input.mouseScrollDelta.y != 0)
        {
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - Input.mouseScrollDelta.y * zoomSpeed, minZoom, maxZoom);
        }

        // Ограничиваем позицию камеры после зума
        ClampCameraPosition();
    }

    private void ClampCameraPosition()
    {
        Vector3 newPosition = mainCamera.transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, backgroundMinX + mainCamera.orthographicSize * mainCamera.aspect, backgroundMaxX - mainCamera.orthographicSize * mainCamera.aspect);
        newPosition.y = Mathf.Clamp(newPosition.y, backgroundMinY + mainCamera.orthographicSize, backgroundMaxY - mainCamera.orthographicSize);

         
    }
}
