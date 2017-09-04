using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGDefaultStats : RPGStatCollection {

    protected override void ConfigureStats()
    {
        var health = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Health);
        health.StatName = "Health";
        health.StatBaseValue = 100;

        var mana = CreateOrGetStat<RPGStat>(RPGStatType.Mana);
        mana.StatName = "Health";
        mana.StatBaseValue = 2000;
    }
}
