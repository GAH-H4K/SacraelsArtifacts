using UnityEngine;

public class DamagedParticle : MonoBehaviour
{
    public GameObject[] particlePrefab;

    public void SpawnParticle(Vector2 position)
    {
        Instantiate(particlePrefab[Random.Range(0, particlePrefab.Length)], position, Quaternion.identity);
    }
}
