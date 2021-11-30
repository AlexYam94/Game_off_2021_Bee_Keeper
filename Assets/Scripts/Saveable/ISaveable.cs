using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    //Only save per day
    //Save been call when one day end
    void CaptureState(string uid);

    void RestoreState(string uid);
}
