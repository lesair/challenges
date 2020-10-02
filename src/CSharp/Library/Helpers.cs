using System;

namespace CSharp.Library
{
    /// <summary>
    ///     Useful helper methods.
    /// </summary>
    public static class Helpers
    {
        public static string GetValidNodeName<TData>(TData nodeData, string nodeName, Func<string, bool> nodeNameExists)
        {
            if (string.IsNullOrEmpty(nodeName))
                nodeName = nodeData.ToString();
            var n = 0;
            var newNodeName = nodeName;
            while (nodeNameExists(newNodeName))
                newNodeName = $"{nodeName}({++n})";
            return newNodeName;
        }
    }
}