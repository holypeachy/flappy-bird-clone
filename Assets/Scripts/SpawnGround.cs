using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject player;

    [SerializeField] private float groundCooldown = 5f;
    private float timeOfNextGround = 0;

    private void Update()
    {
        if (Time.time > timeOfNextGround && !player.GetComponent<Player>().dead)
        {
            Spawn();
            timeOfNextGround = Time.time + groundCooldown;
        }
    }

    private void Spawn()
    {
        Instantiate(ground, transform.position, new Quaternion(0, 0, 0, 0));
    }
}
