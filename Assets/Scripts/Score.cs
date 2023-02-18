using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    
    PlayerController plController;

    [HideInInspector]
    public static int score;
    [HideInInspector]
    public static int lifes;

    [SerializeField]
    public TextMeshProUGUI pickCoins;
    [SerializeField]
    public TextMeshProUGUI countLifes;

    void Start()
    {
        score = 0;
        lifes = 3;
    }

    private void Update()
    {
        CountCoinsText();
        CountLifesText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            CountCoinsText();
            Destroy(collision.gameObject);
            if (score == 10)
            {
                lifes++;
                score = 0;
            }
        }
        if (collision.gameObject.CompareTag("SpawningField"))
        {
            lifes--;
            CountLifesText();
            if (lifes == 0)
            {
                SceneManager.LoadScene("IntroScene");
            }
        }

        if (collision.gameObject.CompareTag("Enemy") && plController.playerCanDoDamage == false)
        {
            score -= 3;
            Destroy(collision.gameObject);
        }
    }

    public void CountCoinsText()
    {
        pickCoins.text = score.ToString();
    }

    public void CountLifesText()
    {
        countLifes.text = lifes.ToString();
    }
}
