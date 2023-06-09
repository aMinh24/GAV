using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    private Transform playerSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }    
    }
    private void Die()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_DEATH);
        }
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
    }
    private void Restart()
    {
        this.transform.position = playerSpawnPoint.position;
        rb.bodyType = RigidbodyType2D.Dynamic;
        animator.Rebind();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
