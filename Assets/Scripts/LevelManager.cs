using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] public int maxItems;
    private int foundItems = 0;

    [SerializeField] public TMP_Text CountLabel;

    [SerializeField] public GameObject UI_canvas;
    [SerializeField] public GameObject welcome_screen        ;
    [SerializeField] public GameObject win_screen;


    // Start is called before the first frame update
    void Start()
    {

        UpdateObjectCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemsFound()
    {
        foundItems++;
        UpdateObjectCounter();

        if (foundItems >= maxItems)
        {
            UI_canvas.SetActive(false);
            win_screen.SetActive(true);
            
        }
    }

    private void UpdateObjectCounter()
    {
        CountLabel.text = $"{foundItems} / {maxItems}";
    }

    public void ExitLevel() 
    {
        SceneManager.LoadScene(0);
    }

    public void StartGameUI() 
    {
        welcome_screen.SetActive(false);
        UI_canvas.SetActive(true);
        win_screen.SetActive(false);
    }
}
