using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public Camera mainCamera;

    public UIManager uiManager;
    public Cashier cashier;
    public Transform waittingOrderPoint;
    public Transform prepareOrderPoint;
    private void Awake()
    {
        Instance = this;
    }
    public void LookAtTable()
    {
        mainCamera.transform.DORotate(prepareOrderPoint.eulerAngles, 1)
        .OnComplete(() =>
        {
            uiManager.OnStartPrepareOrder();
            cashier.OnStartPrepareOrder();
        });
    }
    public void LookAtCustomer(Customer customer, bool isSuccess)
    {
        mainCamera.transform.DORotate(waittingOrderPoint.eulerAngles, 1)
        .OnComplete(() =>
        {
            customer.OnOrderEnd(isSuccess);
        });
    }
}
