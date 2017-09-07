﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGVital : RPGAttribute, IStatCurrentValueChange {

    private int _statCurrentValue;

    public event EventHandler OnCurrentValueChange;

    public int StatCurrentValue
    {
        get {
            if (_statCurrentValue > StatValue)
            {
                _statCurrentValue = StatValue;
            } else if (_statCurrentValue < 0)
            {
                _statCurrentValue = 0;
            }

            return _statCurrentValue;
        }

        set {
            if (_statCurrentValue != value)
            {
                _statCurrentValue = value;
                TriggerCurrentValueChange();
            }
        }
    }

    public RPGVital()
    {
        _statCurrentValue = 0;
    }

    public void SetCurrentValueToMax()
    {
        StatCurrentValue = StatValue;
    }

    private void TriggerCurrentValueChange()
    {
        if(OnCurrentValueChange != null)
        {
            OnCurrentValueChange(this, null);
        }
    }
}