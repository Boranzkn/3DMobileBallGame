using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f;
    private CurrentDirection cr;
    private bool isPlayerDead;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        isPlayerDead = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerDead)
        {
            RayCastDetector();

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // For Mobile
            {
                ChangeDirection();
                StopPlayer();
            }
            else if (Input.GetKeyDown("space")) // For PC to test everything is OK
            {
                ChangeDirection();
                StopPlayer();
            }
        }
        else
        {
            return;
        }
    }

    private void RayCastDetector()
    {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            StopPlayer();
            isPlayerDead=true;
            this.gameObject.SetActive(false);
            gameManager.EndLevel();
        }
    }

    private enum CurrentDirection
    {
        right, left
    }

    private void ChangeDirection()
    {
        if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
        else if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void StopPlayer()
    {
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finisher"))
        {
            StopPlayer();
            this.gameObject.SetActive(false);
            gameManager.WinLevel();
        }
    }

}
