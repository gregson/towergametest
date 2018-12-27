using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsineFer : MonoBehaviour {
    public int spawnFerRate = 2 ;
    public int stock;
    float timer;
    private GameController gameController;
    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        InvokeRepeating("AddStock", 2f, 1f);
	}

    

    private void AddStock()
    {
        stock += spawnFerRate;
        stock = Mathf.Clamp(stock, 0, 50);
        gameController.AddrecolteCuivre(2);
    }
    // Update is called once per frame
    void Update () {
        
    }
}
