using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;



    // ********** INITIALIZATION **********
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

    public void Start()
    {
        this.score = 0;
        SetScore(this.score);
    }


    // ********** SCORE STUFF **********
    public int GetScore() { return this.score; }
    
    public void AddToScore(int amount)
    {
        this.score += amount;
        GameplayUIManager.Instance.SetScoreText(this.score);
    }

    public void SetScore(int amount)
    {
        this.score = amount;
        GameplayUIManager.Instance.SetScoreText(this.score);
    }



}
