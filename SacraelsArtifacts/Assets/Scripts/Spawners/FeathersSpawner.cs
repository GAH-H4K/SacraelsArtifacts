using UnityEngine;

public class FeathersSpawner : MonoBehaviour
{
    public GameObject FeatherPrefab;
    public float force = 5f;


    private void Update()
    {
        Burst();
    }

    public void Burst()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(FeatherPrefab, transform.position, Quaternion.Euler(0, 0, i * 45));
            obj.GetComponent<Rigidbody2D>().linearVelocity = obj.transform.right * 5f;
        }
    }
}
