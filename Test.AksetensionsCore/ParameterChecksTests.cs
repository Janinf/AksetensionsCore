using System;
using AksetensionsCore;
using NUnit.Framework;
using Shouldly;

namespace Test.AksetensionsCore
{
    [TestFixture]
    public class ParameterChecksTests
    {
        private object _parameter;
        private string _stringParameter;

        [Test]
        public void CheckNotNullTest_NotNull()
        {
            SetParameterAsNotNull();
            _parameter.CheckNotNull().ShouldBe(_parameter);
        }

        [Test]
        public void CheckNotNullTest_Null()
        {
            SetParameterAsNull();
            Should.Throw<ArgumentNullException>(() => _parameter.CheckNotNull())
                .ParamName.ShouldBe("source");
        }

        [Test]
        public void CheckNotNullTest_Null_ParamName()
        {
            SetParameterAsNull();
            Should.Throw<ArgumentNullException>(() => _parameter.CheckNotNull(nameof(_parameter)))
                .ParamName.ShouldBe(nameof(_parameter));
        }

        [Test]
        public void CheckNotNullOrEmpty_NotNullOrEmpty()
        {
            _stringParameter = "d";
            _stringParameter.CheckNotNullOrEmpty().ShouldBe(_stringParameter);
        }

        [Test]
        public void CheckNotNullOrEmpty_NullOrEmpty_ParamName()
        {
            _stringParameter = null;
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrEmpty(nameof(_stringParameter)))
                .Message.ShouldBe($"{nameof(_stringParameter)} cannot be null or empty.");
            _stringParameter = "";
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrEmpty(nameof(_stringParameter)))
                .Message.ShouldBe($"{nameof(_stringParameter)} cannot be null or empty.");
        }

        [Test]
        public void CheckNotNullOrEmpty_NullOrEmpty_NoParamName()
        {
            _stringParameter = null;
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrEmpty())
                .Message.ShouldBe("source cannot be null or empty.");
            _stringParameter = "";
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrEmpty())
                .Message.ShouldBe("source cannot be null or empty.");
        }

        [Test]
        public void CheckNotNullOrWhitespace_NotNullOrWhitespace()
        {
            _stringParameter = "d";
            _stringParameter.CheckNotNullOrEmpty().ShouldBe(_stringParameter);
        }

        [Test]
        public void CheckNotNullOrWhitespace_NullOrWhitespace_ParamName()
        {
            _stringParameter = null;
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrWhiteSpace(nameof(_stringParameter)))
                .Message.ShouldBe($"{nameof(_stringParameter)} cannot be null, empty or consist of only whitespace characters.");
            _stringParameter = "";
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrWhiteSpace(nameof(_stringParameter)))
                .Message.ShouldBe($"{nameof(_stringParameter)} cannot be null, empty or consist of only whitespace characters.");
            _stringParameter = "          ";
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrWhiteSpace(nameof(_stringParameter)))
                .Message.ShouldBe($"{nameof(_stringParameter)} cannot be null, empty or consist of only whitespace characters.");
        }

        [Test]
        public void CheckNotNullOrWhitespace_NullOrWhitespace_NoParamName()
        {
            _stringParameter = null;
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrWhiteSpace())
                .Message.ShouldBe("source cannot be null, empty or consist of only whitespace characters.");
            _stringParameter = "";
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrWhiteSpace())
                .Message.ShouldBe("source cannot be null, empty or consist of only whitespace characters.");
            _stringParameter = "          ";
            Should.Throw<ArgumentException>(() => _stringParameter.CheckNotNullOrWhiteSpace())
                .Message.ShouldBe("source cannot be null, empty or consist of only whitespace characters.");
        }

        private void SetParameterAsNull() => _parameter = null;

        private void SetParameterAsNotNull() => _parameter = new object();
    }
}