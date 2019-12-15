using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble<T> {
	void Damage(T damaeTaken);
}
