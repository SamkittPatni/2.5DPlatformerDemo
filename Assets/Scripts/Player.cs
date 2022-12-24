using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private UIManager _uiManager;
    private GameObject _mainCam;
    private float _speed = 8f;
    private float _gravity = 1.1f;
    private float jump = 13f;
    private float yVelocity;
    private bool hasJumped = false;
    private Vector3 startPosition = new Vector3(-8.7f, 0f, 0f);
    [SerializeField]
    private int coins = 0;
    [SerializeField]
    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _mainCam = GameObject.FindWithTag("MainCamera");
        if (_uiManager == null)
        {
            Debug.Log("UI is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (transform.position.y <= -25f)
        {
            removeLives();
            transform.position = startPosition;
        }

        if (lives == 0)
        {
            playerDeath();
        }
    }

    public void addCoins()
    {
        coins++;
        _uiManager.UpdateCoinsDisplay(coins);
    }

    public void removeLives()
    {
        lives--;
        _uiManager.UpdateLivesDisplay(lives);
    }

    public void playerDeath()
    {
        _uiManager.UpdateGameOverDisplay();
        transform.position = startPosition;
        _mainCam.transform.parent = null;
        Destroy(this.gameObject);
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        if (_controller.isGrounded)
        {
            hasJumped = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jump;
                hasJumped = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && hasJumped == true)
            {
                yVelocity = jump;
                hasJumped = false;
            }
            yVelocity -= _gravity;
        }
        velocity.y = yVelocity;
        _controller.Move(velocity * Time.fixedDeltaTime);
    }

}