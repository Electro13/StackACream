using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int towerSize = 0;

    public GameObject[] iceCreamObjects;
    CameraController cameraController;

    public GameObject gameOver;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();

        //Get input to start game
        StartCoroutine(GameStart());
    }

    //Get input to start game
    IEnumerator GameStart()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                //Once we enter we spawn the first scoop
                Spawn();

                //Break out of this coroutine
                StopAllCoroutines();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    //Get input after game is over
    IEnumerator GameOverInput()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                //Load first scene (Main Menu)
                SceneManager.LoadScene(0); 

                //Break out of coroutine
                StopAllCoroutines();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    //Spawn a new icecream scoop ontop of the camera view with random x value
    public void Spawn()
    {
        float y = 7 + Camera.main.transform.position.y;
        float x = Random.Range(-7, 7);

        int creamNum = Random.Range(0, iceCreamObjects.Length);

        Instantiate(iceCreamObjects[creamNum], new Vector2(x, y), Quaternion.identity);
    }


    public void GameOver()
    {
        //Turn on GameOver screen
        gameOver.SetActive(true);

        //Get input for gameOver screen
        StartCoroutine(GameOverInput());

    }
    
    public void DoNextThing(Icecream lastIcecream)
    {
        //Move camera if the last icecream was above the middle of the screen
        if(lastIcecream.transform.position.y > Camera.main.transform.position.y)
        {
            cameraController.targetPosition = lastIcecream.transform.position.y;
        }

        //Addscore
        score += 5 + towerSize;
        towerSize++;

        //Spawn the next scoop
        Spawn();

    }


}
