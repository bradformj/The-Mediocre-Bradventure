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

        var stamina = CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina);
        stamina.StatName = "Stamina";
        stamina.StatBaseValue = 10;

        var wisdom = CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom);
        wisdom.StatName = "Wisdom";
        wisdom.StatBaseValue = 5;
    }
}
