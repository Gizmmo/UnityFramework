using UnityEngine;
using UnityEditor;
using SimpleJSON;

public class BuildAssetBundles {

	[MenuItem("AssetBundles/Build Asset Bundles")]
	static void BuildABs() {
		string outputPath = "Assets/Resources/AssetBundles";
		
		// Put the bundles in a folder called "AssetBundles" within the
		// Assets/Resources folder.)
		BuildPipeline.BuildAssetBundles(outputPath);
	}
}
