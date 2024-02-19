//////////////////////////////////////////////
//Assignment/Lab/Project: VirtualPet_Treek
//Name: Ahmed Treek
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 2/15/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputPetName;
    [SerializeField] private Button startGameButton;
    [SerializeField] private GameObject mainMenuPanel, gamePanel, mainGamePanel, gameOverPanel;
    [SerializeField] private TMP_Text petNameDisplay, enterNameDisplay, happinessTxt, hungerTxt, energyTxt, ripTxt;

    private Pet createdPet;
    private bool petIsAlive;
    private float hungerDecreaseRate, decreaseHappinessRate, decreaseEnergyRate, timer;

    void Start()
    {
        inputPetName.onValueChanged.AddListener(OnInputFieldChanged); //adds the listener to the method for the input field
        startGameButton.interactable = false; //sets the button to not be interacted with on start
    }

    // Update is called once per frame
    void Update()
    {
        if(petIsAlive == true) //if the pet is alive
        {
            timer = Time.deltaTime; //sets the time for the rate over time formula

            GainHunger(hungerDecreaseRate * timer); //calls the method with the result of the rate over time value being sent to it 
            decreaseHappiness(decreaseHappinessRate * timer);
            DecreaseEnergy(decreaseEnergyRate * timer);

            CheckLoss(); //checks the lose condition

            hungerTxt.text = "Fullness: " + createdPet.Fullness.ToString(); //displays the stats of the pet 
            happinessTxt.text = "Happiness: " + createdPet.Happiness.ToString();
            energyTxt.text = "Energy: " + createdPet.Energy.ToString();

        }
    }

    private void OnInputFieldChanged(string txt)
    {
        //Enables the button if there is text in the input field
        startGameButton.interactable = !string.IsNullOrEmpty(txt);
        
        if(!string.IsNullOrEmpty(txt))
        {
            enterNameDisplay.text = ""; //there is text in the input field
        }
        else
        {
            enterNameDisplay.text = "Enter a name "; //if there is no text in the input field this message will pop up to let the user know
        }
    }

    public void OnSubmitButtonClick()
    {
        gamePanel.SetActive(false);
        string petName = inputPetName.text; //grabs the name the player inputs in the input field
        createdPet = new Pet(petName); //creates a new instance of the pet script
        petIsAlive = true; //the pet is alive

        hungerDecreaseRate = Random.Range(1f, 3f);
        decreaseHappinessRate = Random.Range(1f, 3f); //gives random ranges to decrease rates
        decreaseEnergyRate = Random.Range(1f, 3f);

        petNameDisplay.text = petName; //displays the name of the pet
        hungerTxt.text = "Fullness: " + createdPet.Fullness; //displays the stats of the pet 
        happinessTxt.text = "Happiness: " + createdPet.Happiness;
        energyTxt.text = "Energy: " + createdPet.Energy;

    }

    public void FeedButtonClick()
    {
        createdPet.GainFullness(); //calls the method in the Pet script, so that when the button is clicked the pet is fed
    }

    public void PetButtonClick()
    {
        createdPet.GainHappiness(); //calls the method in the Pet script, so that when the button is clicked the pet is played with/petted
    }

    public void RestButtonClick()
    {
        createdPet.GainEnergy(); //calls the method in the Pet script, so that when the button is clicked the pet is sleeping
    }

    void GainHunger(float value)
    {
        createdPet.Fullness -= value; //over time, subtract the fullness from the rate over time value
        createdPet.Fullness = Mathf.Clamp(createdPet.Fullness, 0f, 100f); //clamps so it doesnt go below 0 or above 100
    }

    void decreaseHappiness(float value)
    {
        createdPet.Happiness -= value; //over time, subtract the happiness from the rate over time value
        createdPet.Happiness = Mathf.Clamp(createdPet.Happiness, 0f, 100f); //clamps so it doesnt go below 0 or above 100
    }

    void DecreaseEnergy(float value)
    {
        createdPet.Energy -= value; //over time, subtract the energy from the rate over time value
        createdPet.Energy = Mathf.Clamp(createdPet.Energy, 0f, 100f); //clamps so it doesnt go below 0 or above 100
    }

    private void CheckLoss()
    {
        string petName = inputPetName.text;

        if (createdPet.Fullness == 0 || createdPet.Energy == 0 || createdPet.Happiness == 0) //if any of the stats reaches 0
        {
            petIsAlive = false; //the game is over
            mainGamePanel.SetActive(false); 
            ripTxt.text = "RIP " + petName; //displays a rip message to the pet
        }
    }

    public void OnPlayButtonClick()
    {
        mainMenuPanel.SetActive(false); 
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnAdoptAgainButtonClick()
    {
        gamePanel.SetActive(true); //brings the panel to re enter a name 
        mainGamePanel.SetActive(true);

        createdPet.Energy = 100;
        createdPet.Fullness = 100;
        createdPet.Happiness = 100;
    }
}
