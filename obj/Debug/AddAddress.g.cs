﻿#pragma checksum "..\..\AddAddress.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "558E99FBB5CF8550063EF2891D0761D33D9B9265"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using proj2018_2019;


namespace proj2018_2019 {
    
    
    /// <summary>
    /// AddAddress
    /// </summary>
    public partial class AddAddress : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Address2TextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DistrictTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CityComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PostalTextBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Valider;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AddAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Annuler;
        
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
            System.Uri resourceLocater = new System.Uri("/proj2018-2019;component/addaddress.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddAddress.xaml"
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
            this.AddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Address2TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DistrictTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CityComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.phoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PostalTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Valider = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\AddAddress.xaml"
            this.Valider.Click += new System.Windows.RoutedEventHandler(this.Valider_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Annuler = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

