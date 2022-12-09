using UnityEngine;

public class DespawnRules : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -15f && gameObject.tag == "Pipes")
        {
            Destroy(gameObject);
            Debug.Log("Pipes Despawned");
        }
        if (transform.position.x < -30f && gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
            Debug.Log("Bounds Despawned");
        }
    }
}
