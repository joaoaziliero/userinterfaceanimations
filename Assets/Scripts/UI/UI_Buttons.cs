using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buttons : MonoBehaviour
{
    [Serializable]
    private class SpawnSettings
    {
        public Button button;
        public GameObject helper;
    }

    [SerializeField] private List<SpawnSettings> _settings;


    private void Awake()
    {
        SetSpawn(_settings).ForEach(tuple => tuple.obs.Subscribe(_ => tuple.act()).AddTo(this));
    }

    private List<(Observable<Unit> obs, Action act)> SetSpawn(List<SpawnSettings> settings)
    {
        return settings
            .Select<SpawnSettings, (Observable<Unit> obs, Action act)>
            (tuple => (tuple.button.OnClickAsObservable(), () => Instantiate(tuple.helper, tuple.button.transform, false)))
            .ToList();
    }
}
