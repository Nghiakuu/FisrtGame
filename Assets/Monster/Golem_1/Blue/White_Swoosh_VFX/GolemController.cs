using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : MonsterController
{
    private float Speed;
    private float PlayerCheckRadius; 
    private LayerMask PlayerMask;
    private bool playerFound = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCheckRadius = 1.5f;
        PlayerMask = LayerMask.GetMask("Player");
        Speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(OnPlayer())
        {
            FollowPlayerXR();
            GetComponent<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", false);
        }
        transform.rotation = Quaternion.identity;
    }
    public bool OnPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, PlayerCheckRadius, PlayerMask);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    if (other.gameObject.CompareTag("Player"))
    {
        GetComponent<Animator>().SetBool("attack", true);
        StartCoroutine(ResetAttack(other.gameObject));    
    }
    }

    
    private IEnumerator ResetAttack(GameObject other)
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().SetBool("attack", false);   
        other.GetComponent<HP>().TakeDamage(GetComponent<HP>().dame); 
    }
}
