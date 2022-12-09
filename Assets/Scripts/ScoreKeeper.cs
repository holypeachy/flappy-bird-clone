using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public int score { get; private set; }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
    }
}