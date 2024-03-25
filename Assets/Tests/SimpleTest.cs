// Copyright (c) 2024 Koji Hasegawa.
// This software is released under the MIT License.

using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class SimpleTest
    {
        private const bool Actual = true;

        [Test]
        public void Test()
        {
            Assert.That(Actual, Is.True);
        }

        [Test]
        public async Task TestAsync()
        {
            await Task.Delay(1);
            Assert.That(Actual, Is.True);
        }

        [UnityTest]
        public IEnumerator UnityTest()
        {
            yield return null;
            Assert.That(Actual, Is.True);
        }
    }
}
