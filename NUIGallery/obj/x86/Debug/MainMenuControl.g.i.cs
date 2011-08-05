﻿#pragma checksum "..\..\..\MainMenuControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C26843CE04FBB5C80020AFCF278FFF5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
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


namespace Ryerson.NUIGallery {
    
    
    /// <summary>
    /// MainMenuControl
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class MainMenuControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button topEdge;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rightEdge;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bottomEdge;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button leftEdge;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainmenugrid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tile1;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tile2;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tile3;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\MainMenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tile4;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KinectGallery-20110707;component/mainmenucontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainMenuControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\MainMenuControl.xaml"
            ((Ryerson.NUIGallery.MainMenuControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\MainMenuControl.xaml"
            ((Ryerson.NUIGallery.MainMenuControl)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.UserControl_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.topEdge = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\MainMenuControl.xaml"
            this.topEdge.Click += new System.Windows.RoutedEventHandler(this.Handle_NavigateUp_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rightEdge = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\MainMenuControl.xaml"
            this.rightEdge.Click += new System.Windows.RoutedEventHandler(this.rightEdge_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bottomEdge = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\MainMenuControl.xaml"
            this.bottomEdge.Click += new System.Windows.RoutedEventHandler(this.bottomEdge_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.leftEdge = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\MainMenuControl.xaml"
            this.leftEdge.Click += new System.Windows.RoutedEventHandler(this.leftEdge_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.mainmenugrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.tile1 = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\MainMenuControl.xaml"
            this.tile1.Click += new System.Windows.RoutedEventHandler(this.tile1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tile2 = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\MainMenuControl.xaml"
            this.tile2.Click += new System.Windows.RoutedEventHandler(this.tile2_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.tile3 = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\MainMenuControl.xaml"
            this.tile3.Click += new System.Windows.RoutedEventHandler(this.tile3_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tile4 = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\MainMenuControl.xaml"
            this.tile4.Click += new System.Windows.RoutedEventHandler(this.tile4_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

