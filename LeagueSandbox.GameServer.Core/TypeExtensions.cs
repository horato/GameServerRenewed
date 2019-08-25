using System;
using System.Linq;

namespace LeagueSandbox.GameServer.Core
{
	public static class TypeExtensions
	{
		public static bool IsInheritedFromGenericBase(this Type type, Type baseType)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == baseType)
				return true;
			if (type.BaseType != null)
				return type.BaseType.IsInheritedFromGenericBase(baseType);

			return false;
		}

		public static bool GenericBaseClassHasArgumentOfTypeInHierarchy(this Type type, Type baseType, Type argumentType)
		{
			if (type.GenericBaseClassHasArgumentOfType(baseType, argumentType))
				return true;
			if (type.BaseType != null)
				return type.BaseType.GenericBaseClassHasArgumentOfTypeInHierarchy(baseType, argumentType);

			return false;
		}

		public static bool GenericBaseClassHasArgumentOfType(this Type type, Type baseType, Type argumentType)
		{
			if (!type.IsGenericType)
				return false;
			if (type.GetGenericTypeDefinition() != baseType)
				return false;

			return type.GetGenericArguments().Any(x => x == argumentType);
		}

		public static Type GetArgumentFromGenericBaseTypeInHierarchy(this Type type, Type baseType, int position)
		{
			var argumentType = type.GetArgumentFromGenericBaseType(baseType, position);
			if (argumentType != null)
				return argumentType;
			if (type.BaseType == null)
				return null;

			return type.BaseType.GetArgumentFromGenericBaseTypeInHierarchy(baseType, position);
		}

		public static Type GetArgumentFromGenericBaseType(this Type type, Type baseType, int position)
		{
			if (!type.IsGenericType)
				return null;
			if (type.GetGenericTypeDefinition() != baseType)
				return null;

			var arguments = type.GetGenericArguments();
			return arguments[position];
		}
	}
}
