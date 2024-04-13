using DG.Tweening;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_Tweening : MonoBehaviour
{
    [Serializable]
    private class TweenSettings
    {
        public float endValue = 0, duration = 0, delay = 0;
    }

    [SerializeField] private List<Transform> _icons;
    [SerializeField] private List<TweenSettings> _settings;

    private void Awake()
    {
        Invoke(nameof(HideObjects), 0);
        Invoke(nameof(ShowObjects), 1);
    }

    private void HideObjects()
    {
        SetAnimations(_icons, new List<TweenSettings>() { new() }).ForEach(obs => obs.Subscribe());
    }

    private void ShowObjects()
    {
        SetAnimations(_icons, _settings).ForEach(obs => obs.Subscribe());
    }

    private List<Observable<Unit>> SetAnimations(List<Transform> icons, List<TweenSettings> settings)
    {
        return icons
            .Select((icon, j) => Observable.Timer(TimeSpan.FromSeconds(j * settings[j % settings.Count].delay))
            .Do(_ => icon.DOScale(settings[j % settings.Count].endValue, settings[j % settings.Count].duration)))
            .ToList();
    }
}
