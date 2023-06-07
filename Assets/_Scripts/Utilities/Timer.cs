using System.Collections;
using UnityEngine;

public static class Timer
{
    public static IEnumerator Countdown(float duration)
    {
        float timePassed = 0;
        float progress = 0;

        while(progress < 1)
        {
            timePassed += Time.deltaTime;
            progress = timePassed / duration;
            yield return progress;
        }
    }
}
