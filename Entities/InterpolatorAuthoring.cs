using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using ifelse.Easings;

namespace ifelse.Easings.Entities
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class InterpolatorAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public EasingType function;
        public float initial;
        public float target;
        public float duration;
        public bool removeOnDone;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new ifelse.Easings.Entities.Interpolator(initial, target, duration, function, removeOnDone));
        }
    }
}
