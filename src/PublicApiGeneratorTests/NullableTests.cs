﻿using PublicApiGeneratorTests.Examples;
using System;
using System.Collections.Generic;
using Xunit;

namespace PublicApiGeneratorTests
{
    // Tests for https://github.com/ApiApprover/ApiApprover/issues/54
    [Trait("NRT", "Nullable Reference Types")]
    public class NullableTests : ApiGeneratorTestsBase
    {
        [Fact]
        public void Should_Annotate_ReturnType()
        {
            AssertPublicApi<ReturnType>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class ReturnType
    {
        public ReturnType() { }
        public string? ReturnProperty { get; set; }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Derived_ReturnType()
        {
            AssertPublicApi<ReturnArgs>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class ReturnArgs : System.EventArgs
    {
        public ReturnArgs() { }
        public string? Target { get; set; }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Ctor_Args()
        {
            AssertPublicApi<NullableCtor>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class NullableCtor
    {
        public NullableCtor(string? nullableLabel, string nope) { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Generic_Event()
        {
            AssertPublicApi<GenericEvent>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class GenericEvent
    {
           public GenericEvent() { }
           public event System.EventHandler<PublicApiGeneratorTests.Examples.ReturnArgs?> ReturnEvent;
    }
}");
        }

        [Fact]
        public void Should_Annotate_Delegate_Declaration()
        {
            AssertPublicApi<DelegateDeclaration>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class DelegateDeclaration
    {
           public DelegateDeclaration() { }
           public delegate string? OnNullableReturn(object sender, PublicApiGeneratorTests.Examples.ReturnArgs? args);
           public delegate string OnReturn(object sender, PublicApiGeneratorTests.Examples.ReturnArgs? args);
    }
}");
        }

        [Fact]
        public void Should_Annotate_Nullable_Array()
        {
            AssertPublicApi<NullableArray>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class NullableArray
    {
        public NullableArray() { }
        public PublicApiGeneratorTests.Examples.ReturnType[]? NullableMethod1() { }
        public PublicApiGeneratorTests.Examples.ReturnType[]?[]? NullableMethod2() { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Nullable_Enumerable()
        {
            AssertPublicApi<NullableEnumerable>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class NullableEnumerable
    {
        public NullableEnumerable() { }
        public System.Collections.Generic.IEnumerable<PublicApiGeneratorTests.Examples.ReturnType?>? Enumerable() { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Generic_Method()
        {
            AssertPublicApi<GenericMethod>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class GenericMethod
    {
        public GenericMethod() { }
        public PublicApiGeneratorTests.Examples.ReturnType? NullableGenericMethod<T1, T2, T3>(T1? t1, T2 t2, T3? t3)
            where T1 :  class
            where T2 :  class
            where T3 :  class { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Skeet_Examples()
        {
            AssertPublicApi<SkeetExamplesClass>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class SkeetExamplesClass
    {
        public System.Collections.Generic.Dictionary<System.Collections.Generic.List<string?>, string[]?> SkeetExample;
        public System.Collections.Generic.Dictionary<System.Collections.Generic.List<string?>, string?[]> SkeetExample2;
        public System.Collections.Generic.Dictionary<System.Collections.Generic.List<string?>, string?[]?> SkeetExample3;
        public SkeetExamplesClass() { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_By_Ref()
        {
            AssertPublicApi<ByRefClass>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class ByRefClass
    {
        public ByRefClass() { }
        public bool ByRefNullableReferenceParam(PublicApiGeneratorTests.Examples.ReturnType rt1, ref PublicApiGeneratorTests.Examples.ReturnType? rt2, PublicApiGeneratorTests.Examples.ReturnType rt3, PublicApiGeneratorTests.Examples.ReturnType? rt4, out PublicApiGeneratorTests.Examples.ReturnType? rt5, PublicApiGeneratorTests.Examples.ReturnType rt6) { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Different_API()
        {
            AssertPublicApi<NullableApi>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class NullableApi
    {
        public PublicApiGeneratorTests.Examples.ReturnType NonNullField;
        public PublicApiGeneratorTests.Examples.ReturnType? NullableField;
        public NullableApi() { }
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<int, int?>?>>? ComplicatedDictionary { get; set; }
        public PublicApiGeneratorTests.Examples.ReturnType NonNullProperty { get; set; }
        public PublicApiGeneratorTests.Examples.ReturnType? NullableProperty { get; set; }
        public string? Convert(string source) { }
        public override bool Equals(object? obj) { }
        public override int GetHashCode() { }
        public PublicApiGeneratorTests.Examples.ReturnType? NullableParamAndReturnMethod(string? nullableParam, string nonNullParam, int? nullableValueType) { }
        public PublicApiGeneratorTests.Examples.ReturnType NullableParamMethod(string? nullableParam, string nonNullParam, int? nullableValueType) { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_System_Nullable()
        {
            AssertPublicApi<SystemNullable>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class SystemNullable
    {
        public readonly int? Age;
        public SystemNullable() { }
        public System.DateTime? Birth { get; set; }
        public float? Calc(double? first, decimal? second) { }
        public System.Collections.Generic.List<System.Guid?> GetSecrets(System.Collections.Generic.Dictionary<int?, System.Collections.Generic.Dictionary<bool?, byte?>> data) { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Generics()
        {
            AssertPublicApi<Generics>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class Generics
    {
           public Generics() { }
           public System.Collections.Generic.List<string?> GetSecretData0() { }
           public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int?>> GetSecretData1() { }
           public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int?>?> GetSecretData2() { }
           public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string?, System.Collections.Generic.List<int>?>>> GetSecretData3(System.Collections.Generic.Dictionary<int?, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<int?>>>>? value) { }
           public System.Collections.Generic.Dictionary<int?, string>? GetSecretData4(System.Collections.Generic.Dictionary<int?, string>? value) { }
    }
}");
        }

        [Fact]
        public void Should_Annotate_Structs()
        {
            AssertPublicApi<Structs>(
@"namespace PublicApiGeneratorTests.Examples
{
    public class Structs
    {
           public System.Collections.Generic.KeyValuePair<string?, int?> field;
           public Structs() { }
    }
}");
        }
    }

#nullable enable

    // ReSharper disable ClassNeverInstantiated.Global
    namespace Examples
    {
        public class ReturnType
        {
            public string? ReturnProperty { get; set; }
        }

        public class ReturnArgs : EventArgs
        {
            public string? Target { get; set; }
        }

        public class NullableCtor
        {
            public NullableCtor(string? nullableLabel, string nope) { }
        }

        public class GenericEvent
        {
            public event EventHandler<ReturnArgs?> ReturnEvent { add { } remove { } }
        }

        public class DelegateDeclaration
        {
            protected delegate string OnReturn(object sender, ReturnArgs? args);
            protected delegate string? OnNullableReturn(object sender, ReturnArgs? args);
        }

        public class Structs
        {
            //public Data<string?> Convert(Data<string> value) => new Data<string?>();
            public KeyValuePair<string?, int?> field;
        }

        public struct Data<T>
        {
            public T Value { get; }
        }

        public class Generics
        {
            public List<string?> GetSecretData0() => null;
            public Dictionary<int, List<int?>> GetSecretData1() => null;
            public Dictionary<int, List<int?>?> GetSecretData2() => null;
            public Dictionary<int, List<KeyValuePair<string?, List<int>?>>> GetSecretData3(Dictionary<int?, List<KeyValuePair<string, List<int?>>>>? value) { return null; }
            public Dictionary<int?, string>? GetSecretData4(Dictionary<int?, string>? value) { return null; }
        }

        public class NullableArray
        {
            public ReturnType[]? NullableMethod1() { return null; }
            public ReturnType[]?[]? NullableMethod2() { return null; }
        }

        public class NullableEnumerable
        {
            public IEnumerable<ReturnType?>? Enumerable() { return null; }
        }

        public class GenericMethod
        {
            public ReturnType? NullableGenericMethod<T1, T2, T3>(T1? t1, T2 t2, T3? t3) where T1 : class where T2 : class where T3 : class { return null; }
        }

        public class SkeetExamplesClass
        {
            public Dictionary<List<string?>, string[]?> SkeetExample = new Dictionary<List<string?>, string[]?>();
            public Dictionary<List<string?>, string?[]> SkeetExample2 = new Dictionary<List<string?>, string?[]>();
            public Dictionary<List<string?>, string?[]?> SkeetExample3 = new Dictionary<List<string?>, string?[]?>();
        }

        public class ByRefClass
        {
            public bool ByRefNullableReferenceParam(ReturnType rt1, ref ReturnType? rt2, ReturnType rt3, ReturnType? rt4, out ReturnType? rt5, ReturnType rt6) { rt5 = null; return false; }
        }

        public class NullableApi
        {
            public ReturnType NonNullField = new ReturnType();
            public ReturnType? NullableField;
            public ReturnType NonNullProperty { get; protected set; } = new ReturnType();
            public ReturnType? NullableProperty { get; set; }
            public ReturnType NullableParamMethod(string? nullableParam, string nonNullParam, int? nullableValueType) { return new ReturnType(); }
            public ReturnType? NullableParamAndReturnMethod(string? nullableParam, string nonNullParam, int? nullableValueType) { return null; }
            public Dictionary<string, Dictionary<string, Dictionary<int, int?>?>>? ComplicatedDictionary { get; set; }
            public override bool Equals(object? obj) => base.Equals(obj);
            public override int GetHashCode() => base.GetHashCode();

            public string? Convert(string source) => source;
        }

        public class SystemNullable
        {
            public readonly int? Age;
            public DateTime? Birth { get; set; }

            public float? Calc(double? first, decimal? second) { return null; }

            public List<Guid?> GetSecrets(Dictionary<int?, Dictionary<bool?, byte?>> data) => null;
        }
    }
    // ReSharper restore ClassNeverInstantiated.Global
    // ReSharper restore UnusedMember.Global
}