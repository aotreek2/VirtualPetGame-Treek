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
    [SerializeField] private GameObject mainMenuPanel, gamePanel, mainGamePanel;
    [SerializeField] private TMP_Text petNameDisplay, enterNameDisplay, happinessTxt, hungerTxt, energyTxt;

    private Pet createdPet;
    private bool petIsAlive;

    void Start()
    {
        inputPetName.onValueChanged.AddListener(OnInputFieldChanged);
        startGameButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        while(petIsAlive == true)
        {
            GainHunger(.6f * Time.deltaTime);
            LoseHappiness(.4f * Time.deltaTime);
            LoseEnergy(.6f * Time.deltaTime);
            CheckLoss();
            UpdateUI();
        }
    }

    private void OnInputFieldChanged(string txt)
    {
        //Enables the button if there is text in the input field
        startGameButton.interactable = !string.IsNullOrEmpty(txt);
        
        if(!string.IsNullOrEmpty(txt))
        {
            enterNameDisplay.text = "";
        }
        else
        {
            enterNameDisplay.text = "Enter a name ";
        }
    }

    public void OnSubmitButtonClick()
    {
        gamePanel.SetActive(false);
        string petName = inputPetName.text;
        createdPet = new Pet(petName);
        petIsAlive = true;

        petNameDisplay.text = petName;
        hungerTxt.text = "Fullness: " + createdPet.Fullness;
        happinessTxt.text = "Happiness: " + createdPet.Happiness;
        energyTxt.text = "Energy: " + createdPet.Energy;

    }

    public void FeedButtonClick()
    {
        createdPet.GainFullness();
    }

    public void PetButtonClick()
    {
        createdPet.GainHappiness();
    }

    public void RestButtonClick()
    {
        createdPet.GainEnergy();
    }

    void GainHunger(float value)
    {
        createdPet.Fullness -= (int)value;
        createdPet.Fullness = Mathf.Max(100, createdPet.Fullness); // Ensure hunger doesn't go below 0
    }

    void LoseHappiness(float value)
    {
        createdPet.Happiness += (int)value;
        createdPet.Happiness = Mathf.Min(100, createdPet.Happiness); // Ensure happiness doesn't exceed 100
    }

    void LoseEnergy(float value)
    {
        createdPet.Energy -= (int)value;
        createdPet.Energy = Mathf.Max(0, createdPet.Energy); // Ensure energy doesn't go below 0
    }

    private void CheckLoss()
    {
        if (createdPet.Fullness == 0 || createdPet.Energy == 0 || createdPet.Happiness == 0)
        {
            petIsAlive = false;
        }
    }

    private void UpdateUI()
    {
        hungerTxt.text = "Fullness: " + createdPet.Fullness;
        happinessTxt.text = "Happiness: " + createdPet.Happiness;
        energyTxt.text = "Energy: " + createdPet.Energy;
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
        gamePanel.SetActive(true);
    }
}
