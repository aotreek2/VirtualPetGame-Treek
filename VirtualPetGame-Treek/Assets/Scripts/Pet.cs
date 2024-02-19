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

public class Pet
{
    public string Name {get; set;} 
    public float Fullness {get; set;}
    public float Happiness {get; set;}
    public float Energy {get; set;}

    public Pet(string name) //adds the constructor for the pet class
    {
        Name = name;
        Fullness = 100;
        Happiness = 100;
        Energy = 100;
    }

    public void GainEnergy()
    {
        Energy += 10; //adds energy when the pet is rested
    }

    public void GainHappiness()
    {
        Happiness += 10; //adds happiness to the pet when played with/petted
    }

    public void GainFullness()
    {
        Fullness += 10; // pet gets less hungry when fed
    }

}
