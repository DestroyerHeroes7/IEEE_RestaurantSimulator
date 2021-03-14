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
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawnCustomer();
    }
    private void SpawnCustomer()
    {
        Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity);
    }
}
