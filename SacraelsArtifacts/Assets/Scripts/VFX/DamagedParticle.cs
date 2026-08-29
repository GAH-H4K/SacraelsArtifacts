using UnityEngine;

public class DamagedParticle : MonoBehaviour
{
    public GameObject particlePrefab;

    public void SpawnParticle(Vector2 position)
    {
        Instantiate(particlePrefab, position, Quaternion.identity);
    }
}
