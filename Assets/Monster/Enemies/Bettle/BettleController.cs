using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettleController : MonsterController
{
    public float Speed;
    private Vector3 firstPosition;

    void Start()
    {
        firstPosition = transform.position; // Lưu trữ vị trí ban đầu
    }

    void Update()
    {
        FollowPlayerL();
        if (Vector3.Distance(transform.position, firstPosition) > 5)
        {
            Destroy(gameObject);
        }
    }

}