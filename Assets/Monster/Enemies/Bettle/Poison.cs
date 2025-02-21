using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is poisoned");
            StartCoroutine(ApplyPoisonDamage(other));
        }
    }

    private IEnumerator ApplyPoisonDamage(Collider2D player)
    {
        float duration = 5f;
        float interval = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float damage = GetComponent<HP>().health*0.1f;
            player.GetComponent<HP>().TakeDamage(damage);
            elapsed += interval;
            yield return new WaitForSeconds(interval);
        }
    }

}
