using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;
    public Transform customerSpawnPoint;
    public Transform customerOrderPoint;
    public Transform customerFinishPoint;
    public GameObject customerPrefab;

    public Color successColor;
    public Color failColor;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawnCustomer();
    }
    public void SpawnCustomer()
    {
        Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity);
    }
}
