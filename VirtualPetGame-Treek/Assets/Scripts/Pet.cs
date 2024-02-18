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
    private string _name;
    private int _fullness;
    private int _happiness;
    private int _energy;

    public Pet(string name)
    {
        _name = name;
        _fullness = 100;
        _happiness = 100;
        _energy = 100;
    }

    public void GainEnergy()
    {
        _energy += 10;
    }

    public void GainHappiness()
    {
       _happiness += 10;
    }

    public void GainFullness()
    {
        _fullness += 10;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Fullness
    {
        get
        {
            return _fullness;
        }
        set
        {
            _fullness = value;
        }
    }

    public int Happiness
    {
        get
        {
            return _happiness;
        }
        set
        {
            _happiness = value;
        }
    }

    public int Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }
}
