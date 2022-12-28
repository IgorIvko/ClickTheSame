using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour
{
    private int _randomEffectIndex;

    private void Start()
    {
        Manager.Events.Destroy3 += CreateDestroyEffect;
    }

    private void CreateDestroyEffect(List<GameObject> destroyedCubes)
    {
        _randomEffectIndex = Random.Range(0, Manager.LevelData.EffectsList.Count);
        foreach(GameObject item in destroyedCubes)
        {
            Instantiate(Manager.LevelData.EffectsList[_randomEffectIndex], item.transform.position, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        Manager.Events.Destroy3 -= CreateDestroyEffect;
    }
}
