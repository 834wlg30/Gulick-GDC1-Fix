/****
 * Created by: William Gulick
 * Date Created: 9/29/2021
 * 
 * Last edited by:
 * Last updated: 9/29/2021
 * 
 * Description: Adds to score on object destruction
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    public int scoreVal = 50;

    private void OnDestroy()
    {
        GameManager.score += scoreVal;
    }

}
