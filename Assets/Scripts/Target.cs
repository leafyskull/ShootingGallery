using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;

    public void Hit()
    {
        Debug.Log($"Target hit! +{scoreValue} points!");
        GameManager.Instance.AddToScore(scoreValue);
        Destroy(gameObject);
    }



}
