using UnityEngine;
using UnityEditor;

public class ClearCache : MonoBehaviour {

	[MenuItem("AssetBundles/Clear Cache")]
	static void CleanCache() {
		if (Caching.CleanCache ()) 
    	{
	   		Debug.LogWarning ("Successfully cleaned all caches.");
		}
        else 
        {
	    	Debug.LogWarning ("Cache was in use.");
		}
	}
}
