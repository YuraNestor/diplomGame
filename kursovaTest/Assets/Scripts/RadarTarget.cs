using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadarTarget : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float attenuationSpeed = 1;
    public UnityEvent onDetect;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var c = spriteRenderer.color;
        c.a =0;
        spriteRenderer.color = c;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Radar detected " + gameObject.name);
        onDetect.Invoke();
        var c = spriteRenderer.color;
        c.a = 1;
        spriteRenderer.color=c;
    }
    void Update()
    {
        var c = spriteRenderer.color;
        c.a-=Time.deltaTime*attenuationSpeed;
        spriteRenderer.color=c;
    }
}
