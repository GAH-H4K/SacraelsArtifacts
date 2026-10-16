using UnityEngine;
using System.Collections;

public class Acid : MonoBehaviour
{

    public playerHealth player;

    public void Start()
    {
        StartCoroutine(FindPlayer());

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (player != null)
        {
            player.Die();
        }
    }

    IEnumerator FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<playerHealth>();
        }

        yield return null;
    }
}
