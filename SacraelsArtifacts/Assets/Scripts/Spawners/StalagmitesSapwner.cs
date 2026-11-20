using System.Collections;
using UnityEngine;

public class StalagmitesSapwner : MonoBehaviour
{
    public GameObject[] StalagmitesPrefabs;
    public float cooldown = 2;

    public bool canSpawn;


    private void Update()
    {
        if(canSpawn)
        {
            StartCoroutine(CreateStalagmite());
        }
    }

    public IEnumerator CreateStalagmite()
    {
        canSpawn = false;
        //pega um bagalho aleatorio pra instanciar
        int stalagmite = Random.Range(0, StalagmitesPrefabs.Length);
        Instantiate(StalagmitesPrefabs[stalagmite], transform.position, Quaternion.identity);

        yield return new WaitForSeconds(cooldown);
        canSpawn = true;
    }
}
