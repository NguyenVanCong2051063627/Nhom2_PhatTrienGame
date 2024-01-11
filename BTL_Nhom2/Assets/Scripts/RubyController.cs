using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RubyControll : MonoBehaviour
{
    public float speed = 3f;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    public int health { get { return currentHealth; } }
    int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
      public AudioClip Rubyhit;
      public AudioClip complete;
    Animator animator;
    AudioSource audioSource;
    Vector2 lookDirection = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;

        audioSource = GetComponent<AudioSource>();

    }
 
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));

            if (hit.collider != null)
            {
                Talk character = hit.collider.GetComponent<Talk>();
                if (character != null)
                {
                    character.DisplayDialog();
                   PlaySound(complete);
                }
            }

        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(Rubyhit);
            
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth <= 0)
        {
            // Dừng game
            Time.timeScale = 0f;

            // Gọi hàm xử lý khi game over (nếu cần)
             LoadGameOverScene();
        }
    

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);


    }
     void LoadGameOverScene()
    {
        // Gọi hàm LoadScene để chuyển đến màn hình game over
        SceneManager.LoadScene("GameOver");
    }
       public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}
