using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGAttribute : RPGStatModifiable, IStatScalable
{
    private int _statLevelCoefficient;

    public int StatLevelCoefficient
    {
        get { return _statLevelCoefficient; }
    }

    public override int StatBaseValue
    {
        get
        {
            return base.StatBaseValue + StatLevelCoefficient;
        }

    }

    public virtual void ScaleStat(int level)
    {
        _statLevelCoefficient = level; //this will be some basic calculation that upgrades items based on level (or tier, maybe??? or both????)
    }
}
