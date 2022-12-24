using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text coins_txt;
    [SerializeField]
    private Text lives_txt;
    [SerializeField]
    private Text gameOver_txt;
    [SerializeField]
    private Text restart_txt;
    void Start()
    {
        gameOver_txt.gameObject.SetActive(false);
        restart_txt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateCoinsDisplay(int coins)
    {
        coins_txt.text = "Coins: " + coins;
    }

    public void UpdateLivesDisplay(int lives)
    {
        lives_txt.text = "Lives: " + lives;
    }

    public void UpdateGameOverDisplay()
    {
        gameOver_txt.gameObject.SetActive(true);
        restart_txt.gameObject.SetActive(true);
    }
}
