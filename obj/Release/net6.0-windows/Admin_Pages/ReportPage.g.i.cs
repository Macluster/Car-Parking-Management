﻿#pragma checksum "..\..\..\..\Admin_Pages\ReportPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CD7ED58A220FA17A17A7FF36E6ADAF26240DD57F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarParker.Admin_Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CarParker.Admin_Pages {
    
    
    /// <summary>
    /// ReportPage
    /// </summary>
    public partial class ReportPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CalenderGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar Calender;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DateLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridTable;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TestName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentGrid;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DateRangelabel;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DateRangeLeftBtn;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Admin_Pages\ReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DateRangeRightBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarParker;component/admin_pages/reportpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Admin_Pages\ReportPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CalenderGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Calender = ((System.Windows.Controls.Calendar)(target));
            
            #line 22 "..\..\..\..\Admin_Pages\ReportPage.xaml"
            this.Calender.SelectedDatesChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Calender_SelectedDatesChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\Admin_Pages\ReportPage.xaml"
            this.Calender.DisplayDateChanged += new System.EventHandler<System.Windows.Controls.CalendarDateChangedEventArgs>(this.Calender_DisplayDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DateLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Admin_Pages\ReportPage.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GridTable = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.TestName = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.ContentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.DateRangelabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.DateRangeLeftBtn = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\Admin_Pages\ReportPage.xaml"
            this.DateRangeLeftBtn.Click += new System.Windows.RoutedEventHandler(this.DateRangeLeftBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DateRangeRightBtn = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\..\Admin_Pages\ReportPage.xaml"
            this.DateRangeRightBtn.Click += new System.Windows.RoutedEventHandler(this.DateRangeRightBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

