/****
 * Created by: William Gulick
 * Date Created: 9/29/2021
 * 
 * Last edited by:
 * Last updated: 9/29/2021
 * 
 * Description: Manages global game behaviors
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region GMSingleton
    static GameManager gm;
    public static GameManager GM { get { return gm; } }

    void GameManagerInScene()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public static int score;
    public string scorePrefix = string.Empty;
    public TMP_Text scoreText = null;
    public TMP_Text deathText = null;
    public GameObject player;

    private void Awake()
    {
        GameManagerInScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
        }
    }

    public static void GameOver()
    {
        if(gm.deathText != null)
        {
            gm.deathText.gameObject.SetActive(true);
        }
    }
}
