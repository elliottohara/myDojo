using System;
using System.Linq.Expressions;
using System.Reflection;

namespace myDojo.Domain.UnitTests
{
    public class SingleProperty : Accessor
    {
        private readonly PropertyInfo _property;

        public SingleProperty(PropertyInfo property)
        {
            _property = property;
        }

        #region Accessor Members

        public string FieldName
        {
            get { return _property.Name; }
        }

        public Type PropertyType
        {
            get { return _property.PropertyType; }
        }

        public Type DeclaringType
        {
            get { return _property.DeclaringType; }
        }


        public PropertyInfo InnerProperty
        {
            get { return _property; }
        }

        public Accessor GetChildAccessor<T>(Expression<Func<T, object>> expression)
        {
            PropertyInfo property = ReflectionHelper.GetProperty(expression);
            return new PropertyChain(new[] {_property, property});
        }

        public string Name
        {
            get { return _property.Name; }
        }

        public void SetValue(object target, object propertyValue)
        {
            if (_property.CanWrite)
            {
                _property.SetValue(target, propertyValue, null);
            }
        }

        public object GetValue(object target)
        {
            return _property.GetValue(target, null);
        }

        public Type OwnerType
        {
            get { return DeclaringType; }
        }

        #endregion

        public static SingleProperty Build<T>(Expression<Func<T, object>> expression)
        {
            PropertyInfo property = ReflectionHelper.GetProperty(expression);
            return new SingleProperty(property);
        }

        public static SingleProperty Build<T>(string propertyName)
        {
            PropertyInfo property = typeof (T).GetProperty(propertyName);
            return new SingleProperty(property);
        }
    }
}