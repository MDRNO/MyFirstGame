using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCoinText(int coin)
    {

        coinText.text = "Coins: " + coin.ToString();
    }

    public void UpdateHealthText(int currenthealth, int maxHealth) 
    { 
     
        healthText.text = currenthealth + "/" + maxHealth.ToString();

        float newCurrentHealth = (float) currenthealth / maxHealth;
        healthSlider.value = newCurrentHealth;
    
    }

   
}
