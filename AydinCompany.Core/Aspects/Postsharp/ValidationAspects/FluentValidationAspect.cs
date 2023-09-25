using System;
using System.Linq;
using AydinCompany.Core.CrossCuttingConserns.Validation.FluentValidation;
using AydinCompany.Core.Entities;
using FluentValidation;
using NHibernate.Util;
using PostSharp.Aspects;

namespace AydinCompany.Core.Aspects.Postsharp.ValidationAspects
{
    //aspect'lerde compiletime(derleme zamanı)'nında serileştirilip koda dahil olması için gerekli attribute'dir.
    [Serializable] //nesnenin durumunu serileştirir. byte dizisi haline getirir. 
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            entities.ForEach(entity =>
            {
                ValidatorTool.FluentValidate(validator, (IEntity)entity);
            });
        }
    }
}
