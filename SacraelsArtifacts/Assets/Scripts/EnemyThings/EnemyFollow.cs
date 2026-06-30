
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour 
{


    private Transform PlayerPosition;

    public float EnemySpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position , EnemySpeed * Time.deltaTime);
    }

}

    

