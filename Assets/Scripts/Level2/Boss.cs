using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int _enemyHealth = 600;
    private Transform _prePlayer;
    private MoneyCountUI _refMoney;
    private EnemySpawner _refSpawner;
    private Color enemyMat;
    private Perks _refPerks;

    void Start()
    {
        _prePlayer = GameObject.FindWithTag("Player").transform;
        _refMoney = GameObject.Find("MoneyCount").GetComponent<MoneyCountUI>();
        _refPerks = GameObject.Find("Character").GetComponent<Perks>();
        enemyMat = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _prePlayer.position) <= 100)
        {
            Vector3 targetDirection = new Vector3(_prePlayer.position.x, transform.position.y, _prePlayer.position.z) -
                                      new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float rotationSpeed = 3f;
            Vector3 newRotation =
                Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (_refPerks.activeDMG == true)
            {
                if (_enemyHealth > 20)
                {
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    var scale = transform.localScale;
                    _enemyHealth -= 40;
                    Destroy(other.gameObject);
                    transform.DOPunchScale(scale / 4, 0.5f, 10, 1f).SetEase(Ease.Linear);
                    tempColor.DOColor(Color.red, 0.3f)
                        .OnComplete(() => gameObject.GetComponent<Renderer>().material.color = enemyMat
                        );
                }
                else if (_enemyHealth <= 20)
                {
                    var scale = transform.localScale;
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        Destroy(gameObject));
                    Destroy(other.gameObject);
                    SceneManager.LoadScene("Win");
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            else if (_refPerks.activeDMG == false)
            {
                if (_enemyHealth > 20)
                {
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    var scale = transform.localScale;
                    _enemyHealth -= 20;
                    Destroy(other.gameObject);
                    transform.DOPunchScale(scale / 4, 0.5f, 10, 1f).SetEase(Ease.Linear);
                    tempColor.DOColor(Color.red, 0.3f)
                        .OnComplete(() => gameObject.GetComponent<Renderer>().material.color = enemyMat
                        );
                }
                else if (_enemyHealth <= 20)
                {
                    var scale = transform.localScale;
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        Destroy(gameObject));
                    Destroy(other.gameObject);
                    SceneManager.LoadScene("Win");
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
}