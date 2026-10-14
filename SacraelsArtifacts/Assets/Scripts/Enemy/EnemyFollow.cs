
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    private Transform PlayerPosition;
    public bool playerInRange;
    public float EnemySpeed;

    public Animator animator;

    private Vector3 OriginalScale;

    void Start()
    {
        StartCoroutine(FindPlayer());
        animator = GetComponentInChildren<Animator>();
        OriginalScale = transform.localScale;
    }

    void Update()
    {
        if (playerInRange == true)
        {
            FollowPlayer();
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            PlayerPosition.position,
            EnemySpeed * Time.deltaTime);

        if (transform.position.x > PlayerPosition.position.x)
        {
            transform.localScale = new Vector3(OriginalScale.x, OriginalScale.y, OriginalScale.z);
        }
        else if (transform.position.x < PlayerPosition.position.x)
        {
            transform.localScale = new Vector3(-OriginalScale.x, OriginalScale.y, OriginalScale.z);
        }


    }
    IEnumerator FindPlayer()
    {
        while (PlayerPosition == null)
        {
            GameObject player =
                GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                PlayerPosition = player.transform;
                yield break;
            }

            yield return null;
        }
    }

}



