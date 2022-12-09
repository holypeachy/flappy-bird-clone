using UnityEngine;

public class MoveEnvironment : MonoBehaviour
{
    [SerializeField] private float environmentSpeed = 3;
    private GameObject player;
    private Player script;


    private void Awake()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<Player>();
    }

    private void Update()
    {
        if (!script.dead)
        {
            transform.Translate(new Vector2(-environmentSpeed * Time.deltaTime, 0));
        }
    }
}
