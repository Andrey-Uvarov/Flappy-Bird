using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{

    [Header("Sound")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume;

    [SerializeField] AudioClip flyUpSound;
    [SerializeField] [Range(0, 1)] float flyUpSoundVolume;

    [SerializeField] AudioClip wingsFlappSound;
    [SerializeField] [Range(0, 1)] float wingsFlappSoundVolume;

    [SerializeField] float velocity = 1f;
    [SerializeField] Manager manager;
    Rigidbody2D rb;
    private bool isAlreadyTouched = false;
    private bool gameover = false;

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
            manager.EnableScore();
            PlayFlyUpSound();
            rb.velocity = Vector2.up * velocity;
        }
        if (Input.GetMouseButtonDown(0) && transform.position.y < 1.1f && gameover == false)
        {
            PlayFlyUpSound();
            rb.velocity = Vector2.up * velocity;
        }
        if (gameover == false)
        {
            transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 20f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameover = true;
        PlayDeathSound();
        manager.GameOver();
    }

    private void PlayWingsFlappSound()
    {
        if (wingsFlappSound == null) { return; }
        AudioSource.PlayClipAtPoint(wingsFlappSound, Camera.main.transform.position, wingsFlappSoundVolume);
    }
    private void PlayFlyUpSound()
    {
        if (flyUpSound == null) { return; }
        AudioSource.PlayClipAtPoint(flyUpSound, Camera.main.transform.position, flyUpSoundVolume);
    }
    private void PlayDeathSound()
    {
        if (deathSound == null) { return; }
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
