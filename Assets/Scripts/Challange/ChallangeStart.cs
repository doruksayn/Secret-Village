using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ChallangeStart : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject closeFence;
    public TextMeshProUGUI challengeTimer;
    public float killCount;
    private MoneyCountUI _refMoney;
    private float startTimer = 30f;
    private string formattedTime;
    private bool challangeStart = false;


    void Start()
    {
        _refMoney = GameObject.Find("MoneyCount").GetComponent<MoneyCountUI>();
    }


    void Update()
    {
        if (challangeStart && startTimer > 0 && killCount < 7)
        {
            startTimer -= Time.deltaTime;
            formattedTime = startTimer.ToString("00");
            challengeTimer.text = formattedTime + " second remaining.";
            if (killCount < 3 && startTimer <= 0)
            {
                challengeTimer.text = "You failed.";
                gameObject.GetComponent<BoxCollider>().enabled = true;
                closeFence.SetActive(false);
                enemySpawner.SetActive(false);
                challangeStart = false;
                killCount = 0;
            }
        }
        else if (killCount >= 7 && challangeStart)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            challengeTimer.text = "Congratulations you earn 50 $";
            closeFence.SetActive(false);
            enemySpawner.SetActive(false);
            _refMoney.money += 50;
            killCount = 0;
            challangeStart = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            challengeTimer.text = "Press F to start challenge.";

            if (Input.GetKeyDown(KeyCode.F))
            {
                killCount = 0;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                enemySpawner.SetActive(true);
                enemySpawner.GetComponent<CustomEnemySpawner>().enemyCounter = 0;
                closeFence.SetActive(true);
                challengeTimer.text = "Challenge starts in 5 seconds.";
                StartCoroutine(changeText());
                StartCoroutine(startChallenge());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            challengeTimer.text = "";
        }
    }


    IEnumerator startChallenge()
    {
        yield return new WaitForSeconds(5);
        challangeStart = true;
        yield return null;
    }

    IEnumerator changeText()
    {
        yield return new WaitForSeconds(2);
        challengeTimer.text = "You need to kill 7 enemy in 30 second without dying.";
        yield return null;
    }
}