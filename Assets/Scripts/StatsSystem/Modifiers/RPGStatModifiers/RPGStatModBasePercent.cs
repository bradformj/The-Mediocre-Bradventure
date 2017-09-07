using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatModBasePercent :  RPGStatModifier
{
    public RPGStatModBasePercent(float value) : base(value)
    {
    }

    public RPGStatModBasePercent(float value, bool stacks) : base(value, stacks)
    {
    }

    public override int Order
    {
        get
        {
            return 1;
        }
    }

    public override int ApplyModifier(int statValue, float modValue)
    {
        return (int)(statValue * modValue);
    }


}
