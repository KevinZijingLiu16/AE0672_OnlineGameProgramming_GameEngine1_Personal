using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);


        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit");

            StartCoroutine(DestroyEnemy(collision.gameObject));

        }
    }

    IEnumerator DestroyEnemy(GameObject enemy)
    {
        
        Renderer enemyRenderer = enemy.GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = Color.red;
        }

      
        yield return new WaitForSeconds(2f);

        
        Destroy(enemy);
    }
}
