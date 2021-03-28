using NUnit.Framework;
using RomanMath.Impl;
using System;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var result = Service.Evaluate("IV+II*V");
			Assert.AreEqual(14, result);
		}

		[Test]
		public void Test2()
        {
			var result = SolveExpression.PolishMethod( new string[] { "4", "2", "5", "*", "+" });
			Assert.AreEqual(14, result);
		}

		[Test]
		public void InvalidParameters_ThrowsException()
		{
			Assert.Throws<ArgumentException>(() => Service.Evaluate(null));
		}

	}
}