using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace myDojo.Domain.UnitTests
{
    public static class ReflectionHelper
    {
        public static bool MeetsSpecialGenericConstraints(Type genericArgType, Type proposedSpecificType)
        {
            var gpa = genericArgType.GenericParameterAttributes;
            var constraints = gpa & GenericParameterAttributes.SpecialConstraintMask;

            // No constraints, away we go!
            if (constraints == GenericParameterAttributes.None)
                return true;

            // "class" constraint and this is a value type
            if ((constraints & GenericParameterAttributes.ReferenceTypeConstraint) != 0
                && proposedSpecificType.IsValueType )
            {
                return false;
            }
                   
            // "struct" constraint and this is a value type
            if ((constraints & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0
                && ! proposedSpecificType.IsValueType)
            {
                return false;
            }

            // "new()" constraint and this type has no default constructor
            if ((constraints & GenericParameterAttributes.DefaultConstructorConstraint) != 0
                && proposedSpecificType.GetConstructor(Type.EmptyTypes) == null )
            {
                return false;
            }

            return true;
        }

        public static PropertyInfo GetProperty<MODEL>(Expression<Func<MODEL, object>> expression)
        {
            MemberExpression memberExpression = getMemberExpression(expression);
            return (PropertyInfo)memberExpression.Member;
        }

        public static PropertyInfo GetProperty<MODEL, T>(Expression<Func<MODEL, T>> expression)
        {
            MemberExpression memberExpression = getMemberExpression(expression);
            return (PropertyInfo)memberExpression.Member;
        }

        private static MemberExpression getMemberExpression<MODEL, T>(Expression<Func<MODEL, T>> expression)
        {
            MemberExpression memberExpression = null;
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }


            if (memberExpression == null) throw new ArgumentException("Not a member access", "member");
            return memberExpression;
        }

        public static Accessor GetAccessor<MODEL>(Expression<Func<MODEL, object>> expression)
        {
            MemberExpression memberExpression = getMemberExpression(expression);

            return GetAccessor(memberExpression);
        }

        public static Accessor GetAccessor(MemberExpression memberExpression)
        {
            var list = new List<PropertyInfo>();

            while (memberExpression != null)
            {
                list.Add((PropertyInfo)memberExpression.Member);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            if (list.Count == 1)
            {
                return new SingleProperty(list[0]);
            }

            list.Reverse();
            return new PropertyChain(list.ToArray());
        }

        public static Accessor GetAccessor<MODEL, T>(Expression<Func<MODEL, T>> expression)
        {
            MemberExpression memberExpression = getMemberExpression(expression);

            return GetAccessor(memberExpression);
        }

        public static MethodInfo GetMethod<T>(Expression<Func<T, object>> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }

        public static MethodInfo GetMethod<DELEGATE>(Expression<DELEGATE> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }

        public static MethodInfo GetMethod<T, U>(Expression<Func<T, U>> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }

        public static MethodInfo GetMethod<T, U, V>(Expression<Func<T, U, V>> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }

        public static MethodInfo GetMethod<T>(Expression<Action<T>> expression)
        {
            var methodCall = (MethodCallExpression)expression.Body;
            return methodCall.Method;
        }


        public static T GetAttribute<T>(this ICustomAttributeProvider provider) where T : Attribute
        {
            object[] atts = provider.GetCustomAttributes(typeof(T), true);
            return atts.Length > 0 ? atts[0] as T : null;
        }

        public static void ForAttribute<T>(this ICustomAttributeProvider provider, Action<T> action) where T : Attribute
        {
            foreach (T attribute in provider.GetCustomAttributes(typeof(T), true))
            {
                action(attribute);
            }
        }

        public static void ForAttribute<T>(this Accessor accessor, Action<T> action) where T : Attribute
        {
            foreach (T attribute in accessor.InnerProperty.GetCustomAttributes(typeof(T), true))
            {
                action(attribute);
            }
        }
    }
}