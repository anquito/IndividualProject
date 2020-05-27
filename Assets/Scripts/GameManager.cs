using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Place holders to allow connecting to other objects
    public Transform spawnPoint;
    public GameObject player;
    public GameObject spawnManager;
    public GameObject finishZone;
    public ParticleSystem steamParticle;
    public ParticleSystem dustParticle;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    //public TextMeshProUGUI gameWonText;
    public GameObject titleScreen;
    public Button restartButton;

    // Flags that control the state of the game
    private float elapsedTime = 0;
    private bool isRunning = false;
    public bool isFinished = false;
    public bool isWon = false;

    // So that we can access the player's controller from this script
    public FirstPersonController fpsController;

    private SpawnManager spawner;


    // Use this for initialization
    void Start()
    {
        // Finds the First Person Controller script on the Player
        fpsController = player.GetComponent<FirstPersonController>();

        spawner = spawnManager.GetComponent<SpawnManager>();

        // Disables controls at the start.
        fpsController.enabled = false;

        spawner.enabled = false;

        steamParticle.Stop();
        dustParticle.Stop();
    }


    //This resets to game back to the way it started
    public void StartGame()
    {
        elapsedTime = 0;
        UpdateTime();
        isRunning = true;
        isFinished = false;
        isWon = false;

        // Move the player to the spawn point, and allow it to move.
        PositionPlayer();
        fpsController.enabled = true;

        spawner.enabled = true;

        steamParticle.Play();
        dustParticle.Play();

        titleScreen.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Add time to the clock if the game is running
        if (isRunning)
        {
            elapsedTime = elapsedTime + Time.deltaTime;
            timeText.text = "Time: " + elapsedTime;
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        timeText.text = "Time: " + ((int)elapsedTime).ToString();
    }


    //Runs when the player needs to be positioned back at the spawn point
    public void PositionPlayer()
    {
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
    }


    // Runs when the player enters the finish zone
    public void FinishedGame()
    {
        isRunning = false;
        isFinished = true;
        fpsController.enabled = false;

        spawner.enabled = false;

        steamParticle.Stop();
        dustParticle.Stop();

        //if (this.isWon == true)
        //{
        //    gameOverText.text = "You Win!";
        //}
        //else if (this.isWon == false)
        //{
        //    gameOverText.text = "You Lost!";
        //}

        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over!\n\n Your Time: " + ((int)elapsedTime).ToString() + " Seconds";
        restartButton.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //This section creates the Graphical User Interface (GUI)
    //void OnGUI()
    //{

    //    if (!isRunning)
    //    {
    //        string message;

    //        if (isFinished)
    //        {
    //            message = "Press Enter to Play Again";
    //        }
    //        else
    //        {
    //            message = "Click or Press Enter to Play";
    //        }

    //        //Define a new rectangle for the UI on the screen
    //        Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

    //        if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
    //        {
    //            //start the game if the user clicks to play
    //            StartGame();
    //        }
    //    }

    //    // If the player finished the game, show the final time
    //    if (isFinished)
    //    {
    //        GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Your Time Was");
    //        GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
    //    }
    //    else if (isRunning)
    //    {
    //        // If the game is running, show the current time
    //        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
    //        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
    //    }
    //}
}
