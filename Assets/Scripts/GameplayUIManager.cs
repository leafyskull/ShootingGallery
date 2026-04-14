using TMPro;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    public static GameplayUIManager Instance;
    [SerializeField] private TMP_Text scoreText;



    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }   
    }

    public void SetScoreText(int amount)
    {
        this.scoreText.text = $"Score: {amount}";
    }
    


}
