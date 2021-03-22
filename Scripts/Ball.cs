using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    Vector3 offset;
    public static bool startGame, launched;
    Rigidbody2D rb;
    AudioSource myAudioSource;
    int rand1,rand2;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - paddle.transform.position;
        startGame = false;
        launched = false;
        rb = this.GetComponent<Rigidbody2D>();
        myAudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!startGame) this.transform.position = paddle.transform.position + offset;
        if(Input.GetKeyDown(KeyCode.Space)) startGame = true;
        if(startGame && !launched) {
            rb.velocity = new Vector2(3f,15f);
            launched = true;
        }
        if(LevelManager.playerWin) {
            Destroy(rb);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(startGame) myAudioSource.Play();
        rand1 = Mathf.RoundToInt(Random.Range(0,10));
        rand2 = Mathf.RoundToInt(Random.Range(0,10));
        if(rand1 == rand2) {
            Debug.Log("MATCH!");
            if(rb.velocity.x > 0 && rb.velocity.y > 0) {
                rb.velocity = new Vector2(rb.velocity.x + .01f, rb.velocity.y + .01f);
            }
            else if(rb.velocity.x > 0 && rb.velocity.y < 0) {
                rb.velocity = new Vector2(rb.velocity.x + .01f, rb.velocity.y - .01f);
            }
            else if(rb.velocity.x < 0 && rb.velocity.y > 0) {
                rb.velocity = new Vector2(rb.velocity.x - .01f, rb.velocity.y - .01f);
            }
            else if(rb.velocity.x < 0 && rb.velocity.y < 0) {
                rb.velocity = new Vector2(rb.velocity.x - .01f, rb.velocity.y - .01f);
            }
        }
        
    }
 }
