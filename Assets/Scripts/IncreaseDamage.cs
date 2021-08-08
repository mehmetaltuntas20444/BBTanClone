using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
         healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
           healthManager.damage += 1;
           this.gameObject.SetActive(false);
        }
    }
}
