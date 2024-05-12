// Copyright (c) 2024 Koji Hasegawa.
// This software is released under the MIT License.

#if UNITY_EDITOR
using NUnit.Framework;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class TestCallbacksTest : ICallbacks
    {
        private static bool s_isRunStartedCallback;

        [Test]
        public void RunStartedCallbackOnPlayModeTests()
        {
            Assert.That(s_isRunStartedCallback, Is.True);
        }

        #region ICallbacks

        [InitializeOnLoadMethod]
        private static void SetupCallbacks()
        {
            var api = ScriptableObject.CreateInstance<TestRunnerApi>();
            api.RegisterCallbacks(new TestCallbacksTest());
        }

        /// <inheritdoc/>
        public void RunStarted(ITestAdaptor testsToRun)
        {
            s_isRunStartedCallback = true;
            Debug.Log("RunStarted callback received.");
        }

        /// <inheritdoc/>
        public void RunFinished(ITestResultAdaptor result)
        {
        }

        /// <inheritdoc/>
        public void TestStarted(ITestAdaptor test)
        {
        }

        /// <inheritdoc/>
        public void TestFinished(ITestResultAdaptor result)
        {
        }

        #endregion
    }
}
#endif
