using System.Collections;
using UnityEngine;

public class FeathersSpawner : MonoBehaviour
{
    public GameObject FeatherPrefab;
    public float force = 5f;
    public float CoolDown = 3;

    public bool CanBurst = true;

    private void OnEnable()
    {
        CanBurst = true;
    }
    private void Update()
    {
        if (CanBurst == true)
        {
            StartCoroutine(BurstCooldown());
        }
    }
    

    public void Burst()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject obj = Instantiate(FeatherPrefab, transform.position, Quaternion.Euler(0, 0, i * 20));
            obj.GetComponent<Rigidbody2D>().linearVelocity = obj.transform.right * force;
        }
    }

    public IEnumerator BurstCooldown()
    {
        CanBurst = false;
        yield return new WaitForSeconds(1f);
        Burst();
        yield return new WaitForSeconds(CoolDown);
        CanBurst = true;
    }
}
