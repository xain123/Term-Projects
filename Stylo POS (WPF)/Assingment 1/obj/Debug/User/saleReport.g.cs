﻿#pragma checksum "..\..\..\User\saleReport.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "960D0A4E6EB449F15F01FA43E2B1BBB97B46D346"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assingment_1.User;
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


namespace Assingment_1.User {
    
    
    /// <summary>
    /// saleReport
    /// </summary>
    public partial class saleReport : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_btn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button search_btn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_btn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l7;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l8;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker from;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker to;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\User\saleReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Assingment 1;component/user/salereport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\User\saleReport.xaml"
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
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.back_btn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\User\saleReport.xaml"
            this.back_btn.Click += new System.Windows.RoutedEventHandler(this.back_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.search_btn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\User\saleReport.xaml"
            this.search_btn.Click += new System.Windows.RoutedEventHandler(this.search_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.view_btn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\User\saleReport.xaml"
            this.view_btn.Click += new System.Windows.RoutedEventHandler(this.view_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.l7 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.l8 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.from = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.to = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

