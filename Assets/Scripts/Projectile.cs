using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }
    public void Explode() {
        UnityEngine.Debug.Log("EXPLODE");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 2) {
                player.GetComponent<Player>().TakeDamage(3);
            }
        }
    }
    public void Fall() {
        //
     }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" || collision.gameObject.CompareTag("Player"))
        {
           animator.SetTrigger("Explode");

            GetComponent<Rigidbody2D>().simulated = false;
            Destroy(gameObject, 1f); 

        }
    }
    }
    