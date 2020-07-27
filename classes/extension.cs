using System;

namespace MapWinForms.classes
{
    internal static class extension
    {
        public static void With<T>(this T obj, Action<T> a)
        {
            a(obj);
        }
    }
}