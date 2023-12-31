using UnityEngine;

public class GPUGraph : MonoBehaviour
{
	int func_index;
	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10, 100)]
	int resolution = 10;

	Transform[] points;

	void Awake()
	{
		float step = 2f / resolution;
		var position = Vector3.zero;
		var scale = Vector3.one * step;
		points = new Transform[resolution];
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i] = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform, false);
		}
	}

	void Update()
	{
		float time = Time.time;
		FunctionLibrary.Function function = FunctionLibrary.GetFunction(func_index);
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = function(position.x, time);
			point.localPosition = position;
		}
	}
	public void SetFunc(float value)
    {
		func_index = (int)value;
    }
}