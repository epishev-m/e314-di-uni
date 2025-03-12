using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace E314.DI.Uni.Tests
{

internal sealed class RootContextTests
{
	private GameObject _gameObject;
	private TestContext _context;

	[SetUp]
	public void Setup()
	{
		_gameObject = new GameObject("TestContextObject");
		_context = _gameObject.AddComponent<TestContext>();
		_gameObject.SetActive(true);
	}

	[TearDown]
	public void TearDown()
	{
		if (_gameObject != null) Object.DestroyImmediate(_gameObject);
	}

	[Test]
	public void Context_MethodsCalledInCorrectOrder()
	{
		// Accept
		var expectedOrder = new List<string> { "Bind", "Configure", "Run" };

		// Act
		_context.TestAwake();
		_context.TestStart();

		// Assert
		Assert.That(_context.CallOrder, Is.EqualTo(expectedOrder));
	}

	#region Nested

	public class TestContext : RootContext
	{
		private readonly List<string> _callOrder = new();

		public List<string> CallOrder => _callOrder;

		protected override void Bind(IDiContainer container)
		{
			_callOrder.Add("Bind");
		}

		protected override void Configure()
		{
			_callOrder.Add("Configure");
		}

		protected override void Run()
		{
			_callOrder.Add("Run");
		}

		protected override DiContainer CreateContainer()
		{
			return new DiContainer(new DiContainer.Config(10, 5));
		}

		public void TestAwake()
		{
			Awake();
		}

		public void TestStart()
		{
			typeof(Context).GetMethod("Start",
					System.Reflection.BindingFlags.NonPublic |
					System.Reflection.BindingFlags.Instance)!
				.Invoke(this, null);
		}
	}

	#endregion
}

}