using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGAttribute : RPGStatModifiable, IStatScalable, IStatLinkable
{
    private int _statLevelCoefficient;
    private int _statLinkerValue;
    private List<RPGStatLinker> _statLinkers;

    public int StatLevelCoefficient
    {
        get { return _statLevelCoefficient; }
    }

    public override int StatBaseValue
    {
        get
        {
            return base.StatBaseValue + StatLevelCoefficient + StatLinkerValue;
        }

    }

    public int StatLinkerValue
    {
        get
        {
            return _statLinkerValue;
        }
    }

    public void AddLinker(RPGStatLinker linker)
    {
        _statLinkers.Add(linker);
        linker.OnValueChange += OnLinkerValueChange;
    }

    public void ClearLinkers()
    {
        foreach(var linker in _statLinkers)
        {
            linker.OnValueChange -= OnLinkerValueChange;
        }
        _statLinkers.Clear();
    }

    public virtual void ScaleStat(int level)
    {
        _statLevelCoefficient = level; //this will be some basic calculation that upgrades items based on level (or tier, maybe??? or both????)
        TriggerValueChange();
    }

    public void UpdateLinkers()
    {
        _statLinkerValue = 0;

        foreach(RPGStatLinker link in _statLinkers)
        {
            _statLinkerValue += link.Value;
        }
        TriggerValueChange();
    }

    public RPGAttribute()
    {
        _statLinkers = new List<RPGStatLinker>();
    }

    private void OnLinkerValueChange(object linker, EventArgs args)
    {
        UpdateLinkers();
    }
}
