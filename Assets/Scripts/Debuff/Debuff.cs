using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Debuff {

    string Name { get; }
    bool Finished { get; }

    void Apply(GameObject target);
    void RemoveEffect(GameObject target);

}
