
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour 
{
    private Transform PlayerPosition;
    public bool playerInRange;
    public float EnemySpeed;
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(playerInRange == true)
        {
            FollowPlayer();
        }
    }
    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            PlayerPosition.position,
            EnemySpeed * Time.deltaTime);


    }

}

    

