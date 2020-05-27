using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(StartPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPressed()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.StartGame();
    }
}
