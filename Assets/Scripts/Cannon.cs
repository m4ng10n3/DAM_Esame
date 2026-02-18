using System;
using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Config")]
    public float fireInterval = 5.0f;
    public float clickTimeValue = 1.0f;
    public Transform projectilePrefab;

    public TextMeshProUGUI countdownText;
    
    private float timer;

    private void Awake()
    {
        timer = fireInterval;
        countdownText.text = (Mathf.CeilToInt(timer)).ToString();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Fire();
            timer = fireInterval;
        }
        
        countdownText.text = (Mathf.CeilToInt(timer)).ToString();
    }
    
    private void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
    }

    public void OnClick()
    {
        timer -= clickTimeValue;
    }

    public void DecreaseFireIntervalBy1()
    {
        fireInterval = Mathf.Max(1f, fireInterval - 1f);

        if (timer > fireInterval)
            timer = fireInterval;
    }
}
