﻿#pragma checksum "..\..\Tutorial.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9736BC1D63308819A828DE10956F53BBD0587F82"
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
    /// Tutorial
    /// </summary>
    public partial class Tutorial : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 261 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logout_png;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUser;
        
        #line default
        #line hidden
        
        
        #line 277 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHome;
        
        #line default
        #line hidden
        
        
        #line 278 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnService;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFaq;
        
        #line default
        #line hidden
        
        
        #line 280 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGallery;
        
        #line default
        #line hidden
        
        
        #line 281 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAboutUs;
        
        #line default
        #line hidden
        
        
        #line 282 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContact;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
        #line default
        #line hidden
        
        
        #line 287 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogo;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 302 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cckPost;
        
        #line default
        #line hidden
        
        
        #line 307 "..\..\Tutorial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement me1;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfLekar;component/tutorial.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Tutorial.xaml"
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
            
            #line 260 "..\..\Tutorial.xaml"
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
            
            #line 277 "..\..\Tutorial.xaml"
            this.btnHome.Click += new System.Windows.RoutedEventHandler(this.clkHome);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnService = ((System.Windows.Controls.Button)(target));
            
            #line 278 "..\..\Tutorial.xaml"
            this.btnService.Click += new System.Windows.RoutedEventHandler(this.clkService);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnFaq = ((System.Windows.Controls.Button)(target));
            
            #line 279 "..\..\Tutorial.xaml"
            this.btnFaq.Click += new System.Windows.RoutedEventHandler(this.clkFaq);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnGallery = ((System.Windows.Controls.Button)(target));
            
            #line 280 "..\..\Tutorial.xaml"
            this.btnGallery.Click += new System.Windows.RoutedEventHandler(this.clkGallery);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAboutUs = ((System.Windows.Controls.Button)(target));
            
            #line 281 "..\..\Tutorial.xaml"
            this.btnAboutUs.Click += new System.Windows.RoutedEventHandler(this.clkAboutUs);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnContact = ((System.Windows.Controls.Button)(target));
            
            #line 282 "..\..\Tutorial.xaml"
            this.btnContact.Click += new System.Windows.RoutedEventHandler(this.clkContact);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            
            #line 283 "..\..\Tutorial.xaml"
            this.btnHelp.Click += new System.Windows.RoutedEventHandler(this.clkHelp);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 286 "..\..\Tutorial.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clkLogo);
            
            #line default
            #line hidden
            return;
            case 12:
            this.imgLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 301 "..\..\Tutorial.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.clkNext);
            
            #line default
            #line hidden
            return;
            case 14:
            this.cckPost = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 15:
            this.me1 = ((System.Windows.Controls.MediaElement)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
