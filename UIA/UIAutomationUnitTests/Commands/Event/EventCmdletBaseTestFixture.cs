﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/16/2014
 * Time: 1:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Event
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    using UIAutomation.Commands;
    using UIAutomation.Helpers.Commands;
    using NSubstitute;
    
    /// <summary>
    /// Description of EventCmdletBaseTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class EventCmdletBaseTestFixture
    {
        public EventCmdletBaseTestFixture()
        {
            FakeFactory.Init();
            UIAutomation.Preferences.UseElementsPatternObjectModel = false;
            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
            TestAutomation = null;
        }
        
        internal IAutomation TestAutomation { get; set; }
        
        #region helpers
        private void TestEvent(
            EventCmdletBase cmdlet,
            params AutomationProperty[] properties)
        {
            // Arrange
            IAutomation automation = Substitute.For<IAutomation>();
            automation.RawViewCondition.Returns(Condition.TrueCondition);
            cmdlet.UiaAutomation = automation;
            var command =
                AutomationFactory.GetCommand<EventCommand>(cmdlet);
            
            // Act
            command.Execute();
            
            // Assert
            foreach (var element in cmdlet.InputObject) {
                switch (cmdlet.GetType().Name) {
                    case "RegisterUiaFocusChangedEventCommand":
                        automation.Received(1).AddAutomationFocusChangedEventHandler(
                            new AutomationFocusChangedEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaInvokedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            InvokePattern.InvokedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Element,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaMenuClosedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.MenuClosedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaMenuOpenedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.MenuOpenedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaPropertyChangedEventCommand":
                        automation.Received(1).AddAutomationPropertyChangedEventHandler(
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationPropertyChangedEventHandler(cmdlet.AutomationPropertyChangedEventHandler),
                            cmdlet.AutomationProperty);
                        MbUnit.Framework.Assert.AreEqual<AutomationProperty[]>(properties, cmdlet.AutomationProperty);
                        Xunit.Assert.Equal<AutomationProperty[]>(properties, cmdlet.AutomationProperty);
                        break;
                    case "RegisterUiaStructureChangedEventCommand":
                        automation.Received(1).AddStructureChangedEventHandler(
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new StructureChangedEventHandler(cmdlet.StructureChangedEventHandler));
                        break;
                    case "RegisterUiaTextChangedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            TextPattern.TextChangedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Element,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaTextSelectionChangedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            TextPattern.TextSelectionChangedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Element,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaToolTipClosedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.ToolTipClosedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaToolTipOpenedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.ToolTipOpenedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                        
                    case "RegisterUiaWindowClosedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            WindowPattern.WindowClosedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaWindowOpenedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            WindowPattern.WindowOpenedEvent,
                            Arg.Any<IUiElement>(),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    default:
                        
                    	break;
                }
            }
        }
        #endregion helpers
        
        [Test][Fact]
        public void FocusChangedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaFocusChangedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void InvokedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaInvokedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void MenuClosedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaMenuClosedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void MenuOpenedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaMenuOpenedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void PropertyChangedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaGridRowCountChangedEventCommand {
                InputObject = new IUiElement[] { element } // ,
                // AutomationProperty = 
            };
            TestEvent(
                cmdlet,
                GridPattern.RowCountProperty);
        }
        
        [Test][Fact]
        public void StructureChangedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaStructureChangedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void TextChangedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaTextChangedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void TextSelectionChangedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaTextSelectionChangedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void ToolTipClosedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaToolTipClosedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void ToolTipOpenedEvent()
        {
            // Arrange
            var element =
                // FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
                AutomationFactory.GetUiElement(AutomationElement.RootElement);
                // AutomationFactory.GetUiElement();
            var cmdlet =
                new RegisterUiaToolTipOpenedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void WindowClosedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaWindowClosedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void WindowOpenedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaWindowOpenedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
    }
}
