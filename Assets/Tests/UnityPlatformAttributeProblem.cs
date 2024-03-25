// Copyright (c) 2024 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class UnityPlatformAttributeProblem
    {
        [Test]
        [UnityPlatform(RuntimePlatform.OSXEditor, RuntimePlatform.WindowsEditor, RuntimePlatform.LinuxEditor)]
        public void RunningOnlyInEditor()
        {
            Debug.Log("Test running only in Editor!");
        }

        /// <summary>
        /// This test is running only on Player.
        /// But, this test is inactive in the Player tab of the Test Runner window.
        /// So, test results are invisible, and can not run to "Run Selected".
        /// </summary>
        [Test]
        [UnityPlatform(exclude =
            new[] { RuntimePlatform.OSXEditor, RuntimePlatform.WindowsEditor, RuntimePlatform.LinuxEditor })]
        public void RunningOnlyOnPlayer()
        {
            Debug.Log("Test running only on Player!");
        }
    }
}
