using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public Order order;
    public Text burgerCountText;
    public Text pizzaCountText;
    public Text sphagettiCountText;

    public MeshRenderer meshRenderer;

    public GameObject orderCanvas;
    void Start()
    {
        order = new Order(Random.Range(0, 4), Random.Range(0, 4), Random.Range(0, 4));
        UpdateOrderCanvas();
        GoToOrderPoint();
    }
    private void GoToOrderPoint()
    {
        transform.DOMove(CustomerManager.Instance.customerOrderPoint.position, 3)
        .OnComplete(() =>
        {
            orderCanvas.SetActive(true);
            CameraManager.Instance.LookAtTable();
            Cashier.Instance.SetCurrentCustomer(this);
        });
    }
    public void OnEndPrepareOrder()
    {
        orderCanvas.SetActive(false);
    }
    private void UpdateOrderCanvas()
    {
        burgerCountText.text = order.burgerCount.ToString();
        pizzaCountText.text = order.pizzaCount.ToString();
        sphagettiCountText.text = order.sphagettiCount.ToString();
    }
    public void OnOrderEnd(bool isSuccess)
    {
        meshRenderer.material.color = (isSuccess ? CustomerManager.Instance.successColor : CustomerManager.Instance.failColor);
        transform.DOMove(CustomerManager.Instance.customerFinishPoint.position, 3)
        .OnComplete(() =>
        {
            CustomerManager.Instance.SpawnCustomer();
            Destroy(gameObject);
        });
    }
}
