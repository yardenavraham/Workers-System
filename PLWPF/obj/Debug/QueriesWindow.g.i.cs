﻿#pragma checksum "..\..\QueriesWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1C7D2E4F98B34A8CDD2C6D684F7E5EA8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BE;
using PLWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PLWPF {
    
    
    /// <summary>
    /// QueriesWindow
    /// </summary>
    public partial class QueriesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChildrenNoNanny;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BestNannies;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl page;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idMomComboBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nanniesByAgeChildren;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minOrMax;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label contractByDistance;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BestNannies_WithCompromise;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button contractByDistanceSort;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\QueriesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button contractByDistanceNotSort;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/querieswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QueriesWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ChildrenNoNanny = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\QueriesWindow.xaml"
            this.ChildrenNoNanny.Click += new System.Windows.RoutedEventHandler(this.ChildrenNoNanny_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BestNannies = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\QueriesWindow.xaml"
            this.BestNannies.Click += new System.Windows.RoutedEventHandler(this.BestNannies_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.page = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 4:
            this.idMomComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 50 "..\..\QueriesWindow.xaml"
            this.idMomComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.idMomComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.nanniesByAgeChildren = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\QueriesWindow.xaml"
            this.nanniesByAgeChildren.Click += new System.Windows.RoutedEventHandler(this.nanniesByAgeChildren_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.minOrMax = ((System.Windows.Controls.ComboBox)(target));
            
            #line 53 "..\..\QueriesWindow.xaml"
            this.minOrMax.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.minOrMax_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.contractByDistance = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.BestNannies_WithCompromise = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\QueriesWindow.xaml"
            this.BestNannies_WithCompromise.Click += new System.Windows.RoutedEventHandler(this.BestNannies_WithCompromise_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.contractByDistanceSort = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\QueriesWindow.xaml"
            this.contractByDistanceSort.Click += new System.Windows.RoutedEventHandler(this.contractByDistanceSort_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.contractByDistanceNotSort = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\QueriesWindow.xaml"
            this.contractByDistanceNotSort.Click += new System.Windows.RoutedEventHandler(this.contractByDistanceNotSort_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
