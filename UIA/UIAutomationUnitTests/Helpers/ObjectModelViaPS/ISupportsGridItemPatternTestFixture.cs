﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModelViaPS
{
    using System;
    using System.Windows.Automation;
    using MbUnit.Framework;// using Xunit;
    using System.Management.Automation;
    using NSubstitute;
    using UIAutomation;
    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsGridItemPatternTestFixture.
    /// </summary>
    // [Ignore]
    [MbUnit.Framework.TestFixture]
    public class ISupportsGridItemPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            // MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
//        [Test]// [Fact]
//        public void GridItem_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void GridItem_ImplementsPatternInQuestion()
//        {
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsGridItemPattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsGridItemPattern);
//        }
//        
//        [Test]// [Fact]
//        public void GridItem_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
//        public void GridItem_GridColumn()
//        {
//            // Arrange
//            int expectedValue = 3;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_Column = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridColumn);
//        }
//        
//        [Test]// [Fact]
//        public void GridItem_ColumnSpan()
//        {
//            // Arrange
//            int expectedValue = 4;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_ColumnSpan = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridColumnSpan);
//        }
//        
//        [Test]// [Fact]
//        [Ignore]
//        public void GridItem_ContainingGrid()
//        {
//            // Arrange
//            IUiElement expectedValue = new UiElement();
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_ContainingGrid = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            // Assert.AreEqual(expectedValue as IUiElement, element.GridContainingGrid as IUiElement);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.Name, element.GridContainingGrid.Current.Name);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.AutomationId, element.GridContainingGrid.Current.AutomationId);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ClassName, element.GridContainingGrid.Current.ClassName);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ControlType, element.GridContainingGrid.Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.BoundingRectangle, element.GridContainingGrid.Current.BoundingRectangle);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.NativeWindowHandle, element.GridContainingGrid.Current.NativeWindowHandle);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ProcessId, element.GridContainingGrid.Current.ProcessId);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.IsEnabled, element.GridContainingGrid.Current.IsEnabled);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.IsOffscreen, element.GridContainingGrid.Current.IsOffscreen);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.AcceleratorKey, element.GridContainingGrid.Current.AcceleratorKey);
//        }
//        
//        [Test]// [Fact]
//        public void GridItem_Row()
//        {
//            // Arrange
//            int expectedValue = 5;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_Row = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridRow);
//        }
//        
//        [Test]// [Fact]
//        public void GridItem_RowSpan()
//        {
//            // Arrange
//            int expectedValue = 6;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_RowSpan = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridRowSpan);
//        }
    }
}
