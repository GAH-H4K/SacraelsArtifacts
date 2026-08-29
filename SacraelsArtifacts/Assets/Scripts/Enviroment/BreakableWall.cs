using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public int HitsToBreak = 3;

    public void GetHit()
    {
        HitsToBreak--;
        if(HitsToBreak <= 0)
        {
            Destroy(gameObject);
        }
    }
}
