using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespellEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Respell(other.gameObject));
    }
        }
    private IEnumerator Respell(GameObject other)
    {
        float time = GetComponent<HP>().attackSpeed;
        yield return new WaitForSeconds(time);
        Vector3 pushDirection = (other.transform.position - transform.position).normalized;
        other.GetComponent<Rigidbody2D>().AddForce(pushDirection * 200);
        
    }
}
    

