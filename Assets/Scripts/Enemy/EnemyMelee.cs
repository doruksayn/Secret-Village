using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private int _enemyHealth = 100;
    private Transform _prePlayer;
    private MoneyCountUI _refMoney;
    private Perks _refPerks;
    private Color enemyMaterial;
    private EnemySpawner _refSpawner;
    private float timer = 0f;

    void Start()
    {
        _refSpawner = GameObject.Find("EnemyMeleeSpawner").GetComponent<EnemySpawner>();
        _refMoney = GameObject.Find("MoneyCount").GetComponent<MoneyCountUI>();
        _refPerks = GameObject.Find("Character").GetComponent<Perks>();
        _prePlayer = GameObject.FindWithTag("Player").transform;
        enemyMaterial = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        
        
        if (Vector3.Distance(transform.position, _prePlayer.position) <= 15)
        {
            Vector3 targetDirection = new Vector3(_prePlayer.position.x, transform.position.y, _prePlayer.position.z) -
                                      new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float rotationSpeed = 3f;
            Vector3 newRotation =
                Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
            transform.position += transform.forward * (4 * Time.deltaTime);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer <= 2)
            {
                transform.Rotate(new Vector3(0,15,0) * Time.deltaTime);
            }
            else if (timer <= 4 && timer >= 2)
            {
                transform.Rotate(new Vector3(0,-15,0) * Time.deltaTime);
            }
            else if (timer <= 6 && timer >= 4)
            {
                transform.Rotate(new Vector3(0,-15,0) * Time.deltaTime);
            }
            else if (timer <= 8 && timer >= 6)
            {
                transform.Rotate(new Vector3(0,15,0) * Time.deltaTime);
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
                    transform.DOPunchScale(scale / 4, 0.5f, 10, 1f).SetEase(Ease.Linear);
                    tempColor.DOColor(Color.blue, 0.3f)
                        .OnComplete(() => gameObject.GetComponent<Renderer>().material.color = enemyMaterial);
                    _enemyHealth -= 40;
                    Destroy(other.gameObject);
                }
                else if (_enemyHealth <= 20)
                {
                    var scale = transform.localScale;
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        Destroy(gameObject));
                    Destroy(other.gameObject);
                    _refSpawner.enemyCounter--;
                    _refMoney.money += 5;
                }
            }
            else if (_refPerks.activeDMG == false)
            {
                if (_enemyHealth > 20)
                {
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    var scale = transform.localScale;
                    transform.DOPunchScale(scale / 4, 0.5f, 10, 1f).SetEase(Ease.Linear);
                    tempColor.DOColor(Color.blue, 0.3f)
                        .OnComplete(() => gameObject.GetComponent<Renderer>().material.color = enemyMaterial);
                    _enemyHealth -= 20;
                    Destroy(other.gameObject);
                }
                else if (_enemyHealth <= 20)
                {
                    var scale = transform.localScale;
                    var tempColor = gameObject.GetComponent<Renderer>().material;
                    transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        Destroy(gameObject));
                    Destroy(other.gameObject);
                    _refSpawner.enemyCounter--;
                    _refMoney.money += 5;
                }
            }
        }
    }
}