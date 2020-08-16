using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDA : MonoBehaviour
{
    public float enemiesRanged, enemiesMeleed;
    public GameObject[] rangeEnemies;
    public GameObject[] meleeEnemies;

    private float timer = 2;
    private float timer2 = 2;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rangeEnemies = GameObject.FindGameObjectsWithTag("RangeEnemy");
        meleeEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (timer < 0)
        {
            NextLevel();
        }

        if (timer2 < 0)
        {
            RangedChange();
            MeleedChange();
        }

    }

    void RangedChange()
    {
        rangeEnemies = GameObject.FindGameObjectsWithTag("RangeEnemy");
        meleeEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesRanged > enemiesMeleed)
        {
            foreach (GameObject script in rangeEnemies)
            {
                script.GetComponent<RangeAI>().enabled = false;
                script.GetComponent<RangeEnemie>().enabled = true;
            }
        }
    }

    void MeleedChange()
    {
        rangeEnemies = GameObject.FindGameObjectsWithTag("RangeEnemy");
        meleeEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesMeleed > enemiesRanged)
        {
            foreach (GameObject script in rangeEnemies)
            {
                script.GetComponent<MeleeAI>().health = 2;

            }
        }
    }

    void NextLevel()
    {
        if (meleeEnemies.Length == 0 && rangeEnemies.Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            timer = 2;


        }
    }
}
