using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cashier : MonoBehaviour
{
    public static Cashier Instance;
    public Text burgerCountText;
    public Text pizzaCountText;
    public Text sphagettiCountText;
    public Order order;

    public Customer currentCustomer;

    public GameObject orderCanvas;
    private void Awake()
    {
        Instance = this;
    }
    public void OnStartPrepareOrder()
    {
        order = new Order(0, 0, 0);
        UpdateOrderCanvas();
        orderCanvas.SetActive(true);
    }
    public void OnEndPrepareOrder()
    {
        orderCanvas.SetActive(false);
    }
    public void OnBurgerClick(string mode)
    {
        if (mode == "Add")
            order.burgerCount++;
        else if(order.burgerCount > 0)
            order.burgerCount--;
        UpdateOrderCanvas();
    }
    public void SetCurrentCustomer(Customer customer)
    {
        currentCustomer = customer;
    }
    public void OnPizzaClick(string mode)
    {
        if (mode == "Add")
            order.pizzaCount++;
        else if (order.pizzaCount > 0)
            order.pizzaCount--;
        UpdateOrderCanvas();
    }
    public void OnFinishOrderClick()
    {
        UIManager.Instance.OnEndPrepareOrder();
        OnEndPrepareOrder();
        currentCustomer.OnEndPrepareOrder();
        CameraManager.Instance.LookAtCustomer(currentCustomer, CheckOrder());
    }
    public bool CheckOrder()
    {
        return order.burgerCount == currentCustomer.order.burgerCount && order.pizzaCount == currentCustomer.order.pizzaCount && order.sphagettiCount == currentCustomer.order.sphagettiCount;
    }
    public void OnSphagettiClick(string mode)
    {
        if (mode == "Add")
            order.sphagettiCount++;
        else if (order.sphagettiCount > 0)
            order.sphagettiCount--;
        UpdateOrderCanvas();
    }
    public void UpdateOrderCanvas()
    {
        burgerCountText.text = order.burgerCount.ToString() + 'x';
        pizzaCountText.text = order.pizzaCount.ToString() + 'x';
        sphagettiCountText.text = order.sphagettiCount.ToString() + 'x';
    }
}
