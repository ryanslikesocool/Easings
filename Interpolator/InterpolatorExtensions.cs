// Made with <3 by Ryan Boyer http://ryanjboyer.com

using System;
using UnityEngine;
using Unity.Mathematics;
using System.Collections;

namespace Easings.Interpolator
{
    public static class InterpolatorExtensions
    {
        /// <summary>
        /// Execute an action over the duration of the Interpolator
        /// </summary>
        /// <param name="updateAction">Action to execute every frame</param>
        /// <param name="doneAction">Optional action to execute when the interpolator is done</param>
        /// <param name="deltaTime">Optional delta time.  Leave at -1 to use Time.deltaTime (or Time.unscaledDeltaTime if unscaled is set to true)</param>
        /// <param name="unscaled">Optional unscaled time.  Only works if deltaTime is -1</param>
        /// <returns></returns>
        public static IEnumerator While(this Interpolator interpolator, Action<Interpolator> updateAction, Action<Interpolator> doneAction = null, float deltaTime = -1, bool unscaled = false)
        {
            while (!interpolator.Done)
            {
                interpolator.Update(deltaTime == -1 ? (unscaled ? UnityEngine.Time.unscaledDeltaTime : UnityEngine.Time.deltaTime) : deltaTime);
                updateAction(interpolator);
                yield return null;
            }

            if (doneAction != null)
            {
                doneAction(interpolator);
            }
        }

        /// <summary>
        /// Execute an action over the duration of the Interpolator.  Requires manual interpolator update within updateAction
        /// </summary>
        /// <param name="updateAction">Action to execute every frame.  Requires manual interpolator update</param>
        /// <param name="doneAction">The action to execute when the interpolator is done</param>
        /// <returns></returns>
        public static IEnumerator While(this Interpolator interpolator, Func<float> deltaTime, Action<Interpolator> updateAction, Action<Interpolator> doneAction = null)
        {
            while (!interpolator.Done)
            {
                interpolator.Update(deltaTime());
                updateAction(interpolator);
                yield return null;
            }

            if (doneAction != null)
            {
                doneAction(interpolator);
            }
        }
    }
}