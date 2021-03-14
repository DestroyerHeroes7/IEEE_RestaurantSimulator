using UnityEngine;
public class Order : ScriptableObject
{
    public int burgerCount;
    public int pizzaCount;
    public int sphagettiCount;
    
    public Order(int burgerCount, int pizzaCount, int sphagettiCount)
    {
        this.burgerCount = burgerCount;
        this.pizzaCount = pizzaCount;
        this.sphagettiCount = sphagettiCount;
    }
}
