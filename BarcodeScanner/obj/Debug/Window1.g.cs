﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A91D3E9EE30F03FC7316A30D26CB8B1C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3623
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.PropertyGrid;
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


namespace BarcodeScanner {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\Window1.xaml"
        internal System.Windows.Controls.ComboBox daySelector;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox txtNum1;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button cmdUp1;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button cmdDown1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox txtNum2;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button cmdUp2;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button cmdDown2;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Window1.xaml"
        internal System.Windows.Controls.ComboBox groupSelector;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label groupDisplay;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBlock ActivityDisplay;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Window1.xaml"
        internal System.Windows.Controls.Image ActivityImage;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBlock NextActivityDisplay;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBlock NextActivityStartTime;
        
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
            System.Uri resourceLocater = new System.Uri("/BarcodeScanner;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.daySelector = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtNum1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\Window1.xaml"
            this.txtNum1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtNum1_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmdUp1 = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Window1.xaml"
            this.cmdUp1.Click += new System.Windows.RoutedEventHandler(this.cmdUp1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmdDown1 = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Window1.xaml"
            this.cmdDown1.Click += new System.Windows.RoutedEventHandler(this.cmdDown1_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtNum2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\Window1.xaml"
            this.txtNum2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtNum2_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdUp2 = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\Window1.xaml"
            this.cmdUp2.Click += new System.Windows.RoutedEventHandler(this.cmdUp2_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmdDown2 = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\Window1.xaml"
            this.cmdDown2.Click += new System.Windows.RoutedEventHandler(this.cmdDown2_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.groupSelector = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 70 "..\..\Window1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.groupDisplay = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.ActivityDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.ActivityImage = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.NextActivityDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.NextActivityStartTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
