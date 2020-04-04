using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    /*
     * This Script is just a bunch of variables...
     */
    
    
    public List <GameObject> currentselectedunits;
    public List <GameObject> currentenemies;
    public float globalwarminglevel = 0f;
    public GameObject currentmoveorder;
    public GameObject enemyprefab;
    public GameObject panel;
    public bool ispaused = false;

    //Resources
    public int Iron = 10;

    //Lost or Won
    public bool lost = false;
    public bool won = false;

    //Base Domination: Win by destroying the enemies' base
    public string gamemode = "Base Domination";




    // Start is called before the first frame update
    void Start()
    {
        //Destroy(currentmoveorder);
    }

    // Update is called once per frame
    void Update()
    {
        if(won == true)
        {
            print("You Won! :D");
        }
        else if(lost == true)
        {
            print("You Lost! D:");
        }
    }


    //Some void functions

    public void GotoMainMenu()
    {
        print("Going back to main menu");

        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseMenu()
    {
        panel.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        panel.SetActive(false);
    }

    public void LostGame()
    {

    }

    public void WonGame()
    {

    }

}
