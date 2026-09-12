using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public int HitsToBreak = 3;

    public DamagedParticle damagedParticle;

    public SpriteRenderer spriteRenderer;

    public Sprite almostBrokenWall;

    private int currentParticle = 0;

    public void GetHit()
    {
        Instantiate(damagedParticle.particlePrefab[currentParticle], transform.position, Quaternion.identity);
        HitsToBreak--;

        if(HitsToBreak <= 2)
        {
            spriteRenderer.sprite = almostBrokenWall;
        }
        if(HitsToBreak <= 0)
        {
            Destroy(gameObject);
        }
    }
}
