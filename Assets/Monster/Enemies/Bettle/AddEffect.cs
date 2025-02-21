using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEffect : MonoBehaviour
{
    public GameObject Effect;
    public float duration;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AddEffects(other);
        }
    }
    void AddEffects(Collider2D other)
    {
        GameObject effectInstance = Instantiate(Effect, other.transform.position, Quaternion.identity);
        effectInstance.transform.parent = other.transform;
        other.GetComponent<Animator>().SetBool("isHurt", false);
        Destroy(effectInstance, duration);
    }
}
