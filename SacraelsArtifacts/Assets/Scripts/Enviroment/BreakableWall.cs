using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public int HitsToBreak = 3;

    public DamagedParticle damagedParticle;

    public void GetHit()
    {
        Instantiate(damagedParticle.particlePrefab, transform.position, Quaternion.identity);
        HitsToBreak--;
        if(HitsToBreak <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}
