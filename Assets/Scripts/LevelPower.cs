using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPower : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
         gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
           gameManager.level -= 1;
           this.gameObject.SetActive(false);
        }
    }
}
