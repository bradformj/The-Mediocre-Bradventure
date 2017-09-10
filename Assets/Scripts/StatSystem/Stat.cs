using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {

    //Consider breaking this class up into "modifiable", "linkable", and "vital"... maybe.
    //Consider adding functionality to scale stats.  May be useful for monsters and increasing difficulty.

    public string _statName;
    [SerializeField]
    private int _baseValue;

    private List<int> modifiers = new List<int>();
    public List<StatLinker> linkers = new List<StatLinker>();

    public bool _linkersEnabled = true;
    public bool _modifiersEnabled = true;
    public bool _statEnabled = true;

    public Stat()
    {
        _statName = null;
        _baseValue = 0;
    }

    public Stat(string statName, int value)
    {
        _statName = statName;
        _baseValue = value;
    }

    public int GetValue()
    {
        if (_statEnabled)
        {
            int finalValue = _baseValue;
            float linkerMod = 0;

            //Consider creating a class for StatModifiers similar to stat linkers.
            if (_modifiersEnabled)
                modifiers.ForEach(x => finalValue += x);

            if (_linkersEnabled)
            {
                
                for (int i = 0; i < linkers.Count; i++)
                {

                    linkerMod += linkers[i]._driverStat._baseValue * linkers[i]._multiplier;
                }
            }

            return finalValue + (int)linkerMod; //this typecasting forces the value to always round down.
        }
        return 0;
    }

    //need a clear all function and better "remove" functions, so that we can remove specific modifiers
    public void AddModifier (int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }


    //need a clear all function and better "remove" functions, so that we can remove specific linkers
    public void AddLinker (Stat stat, float multiplier)
    {
        StatLinker linker = new StatLinker(stat, multiplier);

        if (linkers != null)
        {
            linker._multiplier = multiplier;
            linkers.Add(linker);
        }
    }

    public void AddLinker(Stat stat)
    {
        StatLinker linker = new StatLinker(stat);

        if (linkers != null)
        {
            linkers.Add(linker);
        }
    }

    public void RemoveLinker(Stat stat)
    {
        StatLinker linker = new StatLinker(stat);

        if (linkers != null)
        {
            linkers.Remove(linker);
        }
    }

}
