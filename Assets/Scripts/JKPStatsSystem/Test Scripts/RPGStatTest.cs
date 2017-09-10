using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGStatTest : MonoBehaviour {
    private RPGStatCollection stats;

	void Start () {
        stats = new RPGDefaultStats();

        DisplayStatValues();

        var health = stats.GetStat<RPGStatModifiable>(RPGStatType.Health);

        health.AddModifier(new RPGStatModBasePercent(1.0f, false));
        health.AddModifier(new RPGStatModBaseAdd(50f, false));
        health.AddModifier(new RPGStatModTotalPercent(1.0f, false));

        health.UpdateModifiers();

        stats.GetStat<RPGAttribute>(RPGStatType.Stamina).ScaleStat(5);
        stats.GetStat<RPGAttribute>(RPGStatType.Wisdom).ScaleStat(10);

        DisplayStatValues();
	}

    void ForEachEnum<T>(Action<T> action)
    {
        if(action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues()
    {
        ForEachEnum<RPGStatType>((statType) => {
            RPGStat stat = stats.GetStat((RPGStatType)statType);
            if (stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}", stat.StatName, stat.StatValue));
            }
        });
    }
	

}
