using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private GameObject player;

    [SerializeField] private float pipeCooldown = 1f;
    private float timeOfNextPipe = 0;

    private void Update()
    {
        if (Time.time > timeOfNextPipe && !player.GetComponent<Player>().dead)
        {
            Spawn(transform.position);
            timeOfNextPipe = Time.time + pipeCooldown;
        }
    }

    private void Spawn(Vector3 spawnLocation)
    {
        spawnLocation.y = Random.Range(-2f, 2f);
        Instantiate(pipe, spawnLocation, new Quaternion(0,0,0,0)) ;
    }
}
