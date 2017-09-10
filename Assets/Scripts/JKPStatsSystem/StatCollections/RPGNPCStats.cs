using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGNPCStats : RPGStatCollection {

    private int staVal;
    private int wisVal;

    private void Start()
    {
        staVal = (int)Random.Range(8, 12);
        Debug.Log("staVal = " + staVal);
        wisVal = (int)Random.Range(4, 6);
    }

    protected override void ConfigureStats()
    {
        Debug.Log("staValc = " + staVal);
        var stamina = CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina);
        stamina.StatName = "Stamina";
        stamina.StatBaseValue = staVal;

        var wisdom = CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom);
        wisdom.StatName = "Wisdom";
        wisdom.StatBaseValue = wisVal;

        var health = CreateOrGetStat<RPGVital>(RPGStatType.Health);
        health.StatName = "Health";
        health.StatBaseValue = 100;
        health.AddLinker(new RPGStatLinkerBasic(CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina), 10f));
        health.UpdateLinkers();
        health.SetCurrentValueToMax();

        var mana = CreateOrGetStat<RPGVital>(RPGStatType.Mana);
        mana.StatName = "Mana";
        mana.StatBaseValue = 2000;
        mana.AddLinker(new RPGStatLinkerBasic(CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom), 50f));
        mana.UpdateLinkers();
        mana.SetCurrentValueToMax();
    }
}
