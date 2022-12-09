using UnityEngine;

public class PipePoint : MonoBehaviour
{
    private GameObject scoreUI;
    private ScoreKeeper score;

    [SerializeField] private AudioSource point;

    private void Awake()
    {
        scoreUI = GameObject.Find("Score");
        score = scoreUI.GetComponent<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.IncreaseScore();
        point.Play();
    }
}
