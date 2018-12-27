using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private int recolteCuivre;
    // Use this for initialization
    void Start () {
        recolteCuivre = 0;

    }

    public void AddrecolteCuivre(int AddCuivre)
    {
        recolteCuivre += AddCuivre;
       // UpdateScore();
    }

    // Update is called once per frame
    void Update () {
        if(recolteCuivre>0)
        {
            Debug.Log(recolteCuivre);
        }

    }
}
