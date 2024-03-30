// Copyright (c) 2024 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using UnityEngine;

namespace SameNamespace
{
    [TestFixture]
    public class NamespaceTest
    {
        [Test]
        public void ExistSameNameSpace()
        {
            Debug.Log($"{GetType().FullName}");
        }
    }
}
