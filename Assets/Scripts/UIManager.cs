using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Cashier cashier;

    public GameObject orderPanel;
    private void Awake()
    {
        Instance = this;
    }
    public void OnStartPrepareOrder()
    {
        orderPanel.SetActive(true);
    }
    public void OnEndPrepareOrder()
    {
        orderPanel.SetActive(false);
    }
    public void OnBurgerClick(string mode)
    {
        cashier.OnBurgerClick(mode);
    }
    public void OnPizzaClick(string mode)
    {
        cashier.OnPizzaClick(mode);
    }
    public void OnSphagettiClick(string mode)
    {
        cashier.OnSphagettiClick(mode);
    }
    public void OnFinishOrderClick()
    {
        cashier.OnFinishOrderClick();
    }
}
