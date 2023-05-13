using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //For animation of bird
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private GameManager gameManager;
    private AudioSource audioSource;


    public float strength = 5f;
    public float gravity = -9.8f;
    private Vector3 direction;
    
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Start(){
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
        
    }
    
     private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space)){
            direction = Vector3.up * strength; 
            if(FindObjectOfType<GameManager>().sound == true){
                audioSource.Play();
            }
            
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        
    }


    private void AnimateSprite(){
        spriteIndex++;

        if(spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }

        if(spriteIndex < sprites.Length || spriteIndex >= 0){
        spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Obstacle")){
            FindObjectOfType<GameManager>().GameOver();
            Debug.Log("dememez");
        }else if(other.gameObject.CompareTag("Scoring")){
            FindObjectOfType<GameManager>().IncreaseScore();
            Debug.Log("dememez");
        }
    }

    
}


// yukseklik ayari yapilacak