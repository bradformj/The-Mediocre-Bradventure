using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatLinkerBasic : RPGStatLinker {

    private float _ratio;

    public override int Value
    {
        get { return (int)(Stat.StatValue*_ratio); } //This formula should be able to vary
        //e.g. you have a "water dancing" feat where your agility adds to defense and attack and moreso with higher levels of the feat,
        //  where the standard agility attribute only impacts stamina or something.
    }

    public RPGStatLinkerBasic(RPGStat stat, float ratio) : base(stat)
    {
        _ratio = ratio;
    }
}
