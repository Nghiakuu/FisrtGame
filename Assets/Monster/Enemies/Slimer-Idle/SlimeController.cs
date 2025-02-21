using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonsterController
{
    private float Speed;
    private float PlayerCheckRadius; 
    private LayerMask PlayerMask;
    private bool playerFound = false;

    void Start()
    {
        PlayerCheckRadius = 1.5f;
        PlayerMask = LayerMask.GetMask("Player");
        Speed = 0.5f;
    }

    void Update()
    {
        if (OnPlayer())
        {
            FollowPlayerXL();
            GetComponent<Animator>().SetBool("PlayerFound", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("PlayerFound", false);
        }
        transform.rotation = Quaternion.identity;
    }

    public bool OnPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, PlayerCheckRadius, PlayerMask);
    }

    // tự hủy sau 60s
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(120f);
        Destroy(gameObject);
    }

    void OnEnable()
    {
        StartCoroutine(SelfDestruct());
    }

}
