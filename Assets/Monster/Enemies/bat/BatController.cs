using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonsterController
{
    public float Speed;
    private float PlayerCheckRadius; 
    private LayerMask PlayerMask;
    private bool playerFound = false;

    void Start()
    {
        PlayerCheckRadius = 1f;
        PlayerMask = LayerMask.GetMask("Player");
    }

    void Update()
    {
        if (!playerFound && OnPlayer())
        {
            playerFound = true; // Đặt biến cờ khi phát hiện người chơi
            GetComponent<Animator>().SetTrigger("playerFound");
        }

        if (playerFound)
        {
            FollowPlayerR();
        }
    }

    public bool OnPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, PlayerCheckRadius, PlayerMask);
    }
}