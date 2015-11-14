using UnityEngine;
using System.Collections;

public interface Equipment {
    bool broken { get; }

    void fix();
    void damage();
    void upgrade();
}
