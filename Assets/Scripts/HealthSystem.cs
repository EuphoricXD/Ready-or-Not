using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>HealthSystem</c> manages health of the player.
/// </summary>
public class HealthSystem : MonoBehaviour
{
    /// <summary>
    /// Holds number of hearts available to the player
    /// </summary>
    public GameObject[] hearts;

    /// <value>
    /// Property <c>life</c> represents the hearts available to the player.
    /// </value>
    public int life;

    /// <value>
    /// Property <c>timeLoseLife</c> represents the time it takes to lose one heart of health
    /// </value> 
    public int timeLoseLife;

    /// <summary>
    /// Begins loss of health timer
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InvokeMethod(TakeDamage,timeLoseLife, 3));
    }
    /// <summary>
    /// Removes a heart after given amount of time
    /// </summary>
    /// <param> <c>life</c> is being  reduced to take away a heart</param>
    public void TakeDamage()
    {
        life -= 1;
        Destroy(hearts[life].gameObject);
        if (life <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    /// <summary>
    /// Delays call of method
    /// </summary>
    /// <returns>
    /// New wait time for countdown
    /// </returns>
    public IEnumerator InvokeMethod(Action method, float interval, int invokeCount)
    {
        yield return new WaitForSeconds(interval);
        for (int i = 0; i < invokeCount; i++)
        {
            method();

            yield return new WaitForSeconds(interval);
        }
    }
}