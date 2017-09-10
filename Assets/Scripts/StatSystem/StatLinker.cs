using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatLinker {

    //consider referencing the "_drivenStat" here, too, and doing the math in this function
    //for better control/customization of how linkers can influence stats.

    public float _multiplier;
    public Stat _driverStat;

    public StatLinker() : base()
    {
        _driverStat = null;
        _multiplier = 0;
    }

    public StatLinker(Stat stat, float multiplier)
    {
        _driverStat = stat;
        _multiplier = multiplier;
    }

    public StatLinker(Stat stat)
    {
        _driverStat = stat;
        _multiplier = 0;
    }
}
