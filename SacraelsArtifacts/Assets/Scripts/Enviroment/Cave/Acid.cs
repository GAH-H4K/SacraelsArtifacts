using UnityEngine;

public class Acid : MonoBehaviour
{
    public playerHealth player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        player.Die();
    }
}
