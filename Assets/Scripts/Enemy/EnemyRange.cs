using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyRange : MonoBehaviour
{
    protected int _enemyHealth = 100;
    protected Transform _prePlayer;
    private MoneyCountUI _refMoney;
    private EnemySpawner _refSpawner;
    private Color enemyMat;
    private Perks _refPerks;
    private float timer = 0f;

    protected virtual void Start()
    {
        _refSpawner = GameObject.Find("EnemyRangeSpawner").GetComponent<EnemySpawner>();
        _refMoney = GameObject.Find("MoneyCount").GetComponent<MoneyCountUI>();
        _prePlayer = GameObject.FindWithTag("Player").transform;
        _refPerks = GameObject.Find("Character").GetComponent<Perks>();
        enemyMat = gameObject.GetComponent<Renderer>().material.color;
        transform.Rotate(new Vector3(0, 15, 0));
    }

    protected virtual void Update()
    {
        if (Vector3.Distance(transform.position, _prePlayer.position) <= 15)
        {
            Vector3 targetDirection = new Vector3(_prePlayer.position.x, transform.position.y, _prePlayer.position.z) -
                                      new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float rotationSpeed = 3f;
            Vector3 newRotation =
                Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer <= 2)
            {
                transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
            }
            else if (timer <= 4 && timer >= 2)
            {
                transform.Rotate(new Vector3(0, -15, 0) * Time.deltaTime);
            }
            else if (timer <= 6 && timer >= 4)
            {
                transform.Rotate(new Vector3(0, -15, 0) * Time.deltaTime);
            }
            else if (timer <= 8 && timer >= 6)
            {
                transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
            }
            else
            {
                timer = 0f;
            }
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
                    _refMoney.money += 6;
                    _refSpawner.enemyCounter--;
                    var scale = transform.localScale;
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        Destroy(gameObject));
                    Destroy(other.gameObject);
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
                    _refMoney.money += 6;
                    _refSpawner.enemyCounter--;
                    var scale = transform.localScale;
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        Destroy(gameObject));
                    Destroy(other.gameObject);
                }
            }
        }
    }
}