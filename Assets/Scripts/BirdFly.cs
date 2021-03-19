using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    [SerializeField] float velocity = 1f;
    [SerializeField] Manager manager;
    Rigidbody2D rb;
    private bool isAlreadyTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAlreadyTouched == false)
        {
            isAlreadyTouched = true;
            rb.isKinematic = false;
            FindObjectOfType<PipesSpawner>().StartSpawning();
            manager.DisableStartUI();
            rb.velocity = Vector2.up * velocity;
        }
        if (Input.GetMouseButtonDown(0) && transform.position.y < 1.1f)
        { 
            rb.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.GameOver();
    }
}
