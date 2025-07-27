using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public Image health;
    public Image health1;
    public Image health2;
    public Image health3;
    public List<Image> allHealths;
    public int healthCount = 0;
    public Perks playerPerks;

    void Start()
    {
        allHealths.Add(health);
        allHealths.Add(health1);
        allHealths.Add(health2);
        allHealths.Add(health3);
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            if (playerPerks.activeArmor == true)
            {
                playerPerks.activeArmor = false;
                playerPerks.armorUI.SetActive(false);
            }

            else if (playerPerks.activeArmor == false)
            {
                if (playerHealth > 25)
                {
                    for (var i = 0; i < 1; i++)
                    {
                        allHealths[healthCount].gameObject.SetActive(false);
                        healthCount++;
                    }

                    Destroy(other.gameObject);
                    playerHealth -= 25;
                }
                else if (playerHealth <= 25)
                {
                    Destroy(other.gameObject);
                    SceneManager.LoadScene("Scenes/GameOver");
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (playerPerks.activeArmor)
            {
                playerPerks.activeArmor = false;
                playerPerks.armorUI.SetActive(false);
            }
            else if (playerPerks.activeArmor == false)
            {
                if (playerHealth > 50)
                {
                    for (var i = 0; i < 2; i++)
                    {
                        allHealths[healthCount].gameObject.SetActive(false);
                        healthCount++;
                    }

                    playerHealth -= 50;
                }
                else if (playerHealth <= 50)
                {
                    SceneManager.LoadScene("Scenes/GameOver");
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        else if (other.gameObject.CompareTag("SpecialBullet"))
        {
            if (playerPerks.activeArmor)
            {
                playerPerks.activeArmor = false;
                playerPerks.armorUI.SetActive(false);
            }
            else if (playerPerks.activeArmor == false)
            {
                if (playerHealth > 50)
                {
                    for (var i = 0; i < 2; i++)
                    {
                        allHealths[healthCount].gameObject.SetActive(false);
                        healthCount++;
                    }

                    playerHealth -= 50;
                }
                else if (playerHealth <= 50)
                {
                    SceneManager.LoadScene("Scenes/GameOver");
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
}