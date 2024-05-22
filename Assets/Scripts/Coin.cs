using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem coinEffect;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(180 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int minScore = 3, maxScore = 11;
            gameManager.AddScore(Random.Range(minScore, maxScore));
            coinEffect.Play();
            Destroy(gameObject, 0.5f);    
        }
    }
}
