using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Gradient gradient;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer> ();
        renderer.color = gradient.Evaluate(Random.Range(0f,1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
