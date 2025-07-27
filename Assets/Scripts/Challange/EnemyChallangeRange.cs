using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyChallangeRange : EnemyRange
{
    private ChallangeStart _refEnemy;
    private CustomEnemySpawner _refCustomSpawner;
    private Color _enemyMaterial;

    protected override void Start()
    {
        _refCustomSpawner = GameObject.Find("CustomEnemySpawner").GetComponent<CustomEnemySpawner>();
        _refEnemy = GameObject.Find("ChallangeDetector").GetComponent<ChallangeStart>();
        _prePlayer = GameObject.FindWithTag("Player").transform;
        _enemyMaterial = gameObject.GetComponent<Renderer>().material.color;
    }


    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (_enemyHealth > 20)
            {
                var tempColor = gameObject.GetComponent<Renderer>().material;
                var scale = transform.localScale;
                _enemyHealth -= 20;
                Destroy(other.gameObject);
                transform.DOPunchScale(scale / 4, 0.5f, 10, 1f).SetEase(Ease.Linear);
                tempColor.DOColor(Color.red, 0.3f)
                    .OnComplete(() => gameObject.GetComponent<Renderer>().material.color = _enemyMaterial
                    );
            }
            else if (_enemyHealth <= 20)
            {
                _refEnemy.killCount++;
                _refCustomSpawner.enemyCounter--;
                var scale = transform.localScale;
                var tempColor = gameObject.GetComponent<Renderer>().material;
                transform.DOScale(scale / 5, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                    Destroy(gameObject));
                Destroy(other.gameObject);
            }
        }
    }
}