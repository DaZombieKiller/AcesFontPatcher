using UnityEditor;
using System.IO;

internal static class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    private static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "../artifacts/bundles";
        Directory.CreateDirectory(assetBundleDirectory);
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
