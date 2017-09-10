using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatLinkable {
    int StatLinkerValue { get; }

    void AddLinker(RPGStatLinker linker);
    void ClearLinkers();
    void UpdateLinkers();   //this is very similar to modifiers, basically adds the linkers, then updates how the stats work based on the new list of linkers
                            //this may need a "remove linkers" functionality, but may not, we could just clear the linkers, then readd them if something changes.

}
