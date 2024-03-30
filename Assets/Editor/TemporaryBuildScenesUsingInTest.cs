// Copyright (c) 2024 Koji Hasegawa.
// This software is released under the MIT License.

using System.Collections.Generic;
using Editor;
using UnityEditor;
using UnityEditor.TestTools;

[assembly: TestPlayerBuildModifier(typeof(TemporaryBuildScenesUsingInTest))]

namespace Editor
{
    public class TemporaryBuildScenesUsingInTest : ITestPlayerBuildModifier
    {
        public BuildPlayerOptions ModifyOptions(BuildPlayerOptions playerOptions)
        {
            const string SceneNotInBuild = "Assets/Scenes/SceneNotInBuild.unity";

            var scenesInBuild = new List<string>(playerOptions.scenes);
            if (!scenesInBuild.Contains(SceneNotInBuild))
            {
                scenesInBuild.Add(SceneNotInBuild);
            }

            playerOptions.scenes = scenesInBuild.ToArray();
            return playerOptions;
        }
    }
}
