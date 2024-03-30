// Copyright (c) 2024 Koji Hasegawa.
// This software is released under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace Tests
{
    [TestFixture]
    public class LoadSceneTest
    {
        private async Task LoadSceneAsync()
        {
            AsyncOperation asyncOperation;

#if UNITY_EDITOR
            asyncOperation = EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Scenes/SceneNotInBuild.unity",
                new LoadSceneParameters(LoadSceneMode.Single));
#else
            asyncOperation = SceneManager.LoadSceneAsync("SceneNotInBuild");
            // Note: Adding to scenes-in-build with test player build modifier. see Assets/Editor/TemporaryBuildScenesUsingInTest.cs
#endif

            while (asyncOperation.isDone == false)
            {
                await Task.Yield();
            }
        }

        [Test]
        public async Task LoadScene_SceneNotInBuild()
        {
            await LoadSceneAsync();

            await Task.Delay(5000);

            var scene = SceneManager.GetActiveScene();
            Assert.That(scene.name, Is.EqualTo("SceneNotInBuild"));
        }
    }
}
