using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image image;
    [SerializeField] Player player;



    Vector2 positionGap;



    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        image.color = gradient.Evaluate(1f);


         positionGap = transform.position - player.transform.position;

        
    }
    private void Update()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x,player.transform.position.y);
        transform.position = playerPos + positionGap;
        
        
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        image.color = gradient.Evaluate(slider.normalizedValue);
        if(slider.value == 0)
        {
            Destroy(gameObject);
        }
    }
   
}
