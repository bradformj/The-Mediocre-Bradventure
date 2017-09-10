using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatModifiable {

    int StatModifierValue { get; }

    void AddModifier(RPGStatModifier mod);
    void RemoveModfier(RPGStatModifier mod);
    void ClearModifier();
    void UpdateModifiers();

}
