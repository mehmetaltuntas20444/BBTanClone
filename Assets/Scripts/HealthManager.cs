using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int brickHealth;
    private Text healthText;
    private GameManager gameManager;
    public ScoreManager score;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        score = FindObjectOfType<ScoreManager> ();
        gameManager = FindObjectOfType<GameManager>();
        brickHealth = gameManager.level; 
        healthText = GetComponentInChildren<Text> ();  
    }

    void OnEnable(){
        gameManager = FindObjectOfType<GameManager> ();
        brickHealth = gameManager.level;
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = "" + brickHealth;
        if(brickHealth <= 0){
            score.IncreaseScore();
            this.gameObject.SetActive(false);
        }
    }

    void TakeDamege(int damageTake){
        brickHealth -= damageTake;
    }

     void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball"){
            TakeDamege(damage);
        }
    }
}
