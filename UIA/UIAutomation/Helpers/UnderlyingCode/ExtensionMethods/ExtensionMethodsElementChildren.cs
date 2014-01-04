﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 12:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PSTestLib;
    
    /// <summary>
    /// Description of ExtensionMethodsElementChildren.
    /// </summary>
    public static class ExtensionMethodsElementChildren
    {
        // public static IUiEltCollection PerformFindAll(this IUiElement element, TreeScope scope, ControlType controlType)
        public static IUiEltCollection PerformFindAll(this IExtendedModelHolder holder, TreeScope scope, ControlType controlType)
        {
            try {
                return (holder as UiExtendedModelHolder).GetParentElement()
                    .FindAll(
                        scope,
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            controlType));
            } catch (Exception) {
                return new UiEltCollection(true);
                // throw;
            }
        }
        
        public static IExtendedModelHolder GetHolder(this IUiElement element)
        {
            return AutomationFactory.GetUiExtendedModelHolder(element);
        }
    }
}