using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject endGamePanel; // Reference to the UI panel for end game
    public Text endGameText; // Reference to the Text component for end game message

    void Start()
    {
        // Disable the end game panel and clear the text at the start
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
        if (endGameText != null)
        {
            endGameText.text = "";
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, verticalInput * moveSpeed * Time.deltaTime, 0f);
        
        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Game Over - You hit a wall!");
            EndGame();
        }
        else if (other.CompareTag("EndPoint"))
        {
            Debug.Log("You reached the end point!");
            EndGame();
        }
    }

    void EndGame()
    {
        // Show the end game panel and set the text
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }
        if (endGameText != null)
        {
            endGameText.text = "Congratulations! You reached the end."; // Set the end game message
        }
        // Optionally, add more game over logic such as pausing the game or displaying a game over message
    }
}
