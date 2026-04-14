using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;

    public void Hit()
    {
        Debug.Log($"Target hit! +{scoreValue} points!");
        Destroy(gameObject);
    }



}
