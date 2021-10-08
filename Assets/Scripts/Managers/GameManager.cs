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
using UnityEngine.SceneManagement;

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

   [SerializeField] public static int score;
   [SerializeField] public int levelScore;
   [SerializeField] public int levelNum;
   [SerializeField] public int numLevels;
    public string scorePrefix = string.Empty;
    public TMP_Text scoreText = null;
    public TMP_Text deathText = null;
    public GameObject player;

    private void Awake()
    {
        GameManagerInScene();
        levelNum = 0;
        numLevels = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
            levelScore = score;

            if (score >= 5000 && levelNum < numLevels)
            {
                levelScore = 0;
                levelNum++;
                SceneManager.LoadScene(levelNum);
            }
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
