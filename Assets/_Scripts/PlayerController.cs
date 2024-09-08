using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamagable
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 direction;
    public float speed = 5;
    public float maxEnergy = 10f;
    private float energy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        energy = maxEnergy;
        Energy(0);
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("SpeedX", direction.x);
        anim.SetFloat("SpeedY", direction.y);
    }

    private void FixedUpdate() {
        direction.Normalize();
        direction *= speed;
        rb.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    public void Energy(float energyMod) {
        energy += energyMod;
        ScoreController.instance.UpdateScore(energy);
        if (energy <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
