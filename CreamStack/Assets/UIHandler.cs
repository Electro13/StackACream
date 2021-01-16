using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    GameManager gm;


    public TextMeshProUGUI scoreText;
    public Text goscoreText;
    public Text goscoopsText;

    public GameObject Tutorial;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(gm.score.ToString());
        goscoreText.text = gm.score.ToString();
        goscoopsText.text = gm.towerSize.ToString();

        //Turn off tutorial text after pressing return
        if(Input.GetKeyDown(KeyCode.Return) && Tutorial.activeSelf)
        {
            Tutorial.SetActive(false);
        }
    }
}
