using CAFU.Core.Domain.Translator;
using Example.CAFU.Spawner.Data.Entity;
using Example.CAFU.Spawner.Domain.Model;
using UnityEngine;

namespace Examples.Scripts.Domain.Translator
{
    public class SampleModelTranslator : IModelTranslator<SampleEntity, SampleModel>
    {
        public SampleModel Translate(SampleEntity entity)
        {
            return new SampleModel
            {
                PrimaryId = entity.Id,
                Color = entity?.Color ?? Color.white,
            };
        }
    }
}