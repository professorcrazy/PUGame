using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyItem : MonoBehaviour
{
    public float energy = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<IDamagable>()?.Energy(energy);
            Destroy(gameObject);
        }
    }
}
