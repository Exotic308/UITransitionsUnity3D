using UnityEngine;
using System.Collections;

public class StringSimilarity : MonoBehaviour {

	public string first;
	public string second;
	public bool work;

	static int ComputeLevenshteinDistance(string source, string target){
		if ((source == null) || (target == null)) return 0;
		if ((source.Length == 0) || (target.Length == 0)) return 0;
		if (source == target) return source.Length;
		
		int sourceWordCount = source.Length;
		int targetWordCount = target.Length;

		if (sourceWordCount == 0)
			return targetWordCount;
		
		if (targetWordCount == 0)
			return sourceWordCount;
		
		int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

		for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++);
		for (int j = 0; j <= targetWordCount; distance[0, j] = j++);
		
		for (int i = 1; i <= sourceWordCount; i++){
			for (int j = 1; j <= targetWordCount; j++){
				int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
				distance[i, j] = Mathf.Min(Mathf.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
			}
		}
		
		return distance[sourceWordCount, targetWordCount];
	}

	public static double CalculateSimilarity(string source, string target){
		if ((source == null) || (target == null)) return 0.0;
		if ((source.Length == 0) || (target.Length == 0)) return 0.0;
		if (source == target) return 1.0;
		
		int stepsToSame = ComputeLevenshteinDistance(source, target);
		return (1.0 - ((double)stepsToSame / (double)Mathf.Max(source.Length, target.Length)));
	}
}
