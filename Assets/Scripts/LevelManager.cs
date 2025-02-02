using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] public int maxItems;
    private int foundItems = 0;

    [SerializeField] public TMP_Text CountLabel;


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
            SceneManager.LoadScene(0);
        }
    }

    private void UpdateObjectCounter()
    {
        CountLabel.text = $"{foundItems}/{maxItems}";
    }
}
