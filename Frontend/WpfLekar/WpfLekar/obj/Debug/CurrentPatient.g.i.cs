﻿#pragma checksum "..\..\CurrentPatient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1AC70A723D81A2543C7C0750E424CADF86A2280E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfLekar;


namespace WpfLekar {
    
    
    /// <summary>
    /// CurrentPatient
    /// </summary>
    public partial class CurrentPatient : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 223 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logout_png;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUser;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHome;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnService;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFaq;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGallery;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAboutUs;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContact;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\CurrentPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogo;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfLekar;component/currentpatient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CurrentPatient.xaml"
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
            
            #line 222 "..\..\CurrentPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clkLogOut);
            
            #line default
            #line hidden
            return;
            case 2:
            this.logout_png = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.lblUser = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnHome = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\CurrentPatient.xaml"
            this.btnHome.Click += new System.Windows.RoutedEventHandler(this.clkHome);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnService = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\CurrentPatient.xaml"
            this.btnService.Click += new System.Windows.RoutedEventHandler(this.clkService);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnFaq = ((System.Windows.Controls.Button)(target));
            
            #line 241 "..\..\CurrentPatient.xaml"
            this.btnFaq.Click += new System.Windows.RoutedEventHandler(this.clkFaq);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnGallery = ((System.Windows.Controls.Button)(target));
            
            #line 242 "..\..\CurrentPatient.xaml"
            this.btnGallery.Click += new System.Windows.RoutedEventHandler(this.clkGallery);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAboutUs = ((System.Windows.Controls.Button)(target));
            
            #line 243 "..\..\CurrentPatient.xaml"
            this.btnAboutUs.Click += new System.Windows.RoutedEventHandler(this.clkAboutUs);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnContact = ((System.Windows.Controls.Button)(target));
            
            #line 244 "..\..\CurrentPatient.xaml"
            this.btnContact.Click += new System.Windows.RoutedEventHandler(this.clkContact);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            
            #line 245 "..\..\CurrentPatient.xaml"
            this.btnHelp.Click += new System.Windows.RoutedEventHandler(this.clkHelp);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 248 "..\..\CurrentPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clkLogo);
            
            #line default
            #line hidden
            return;
            case 12:
            this.imgLogo = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

