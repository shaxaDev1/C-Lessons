#pragma checksum "..\..\..\..\Pages\ExaminationPages.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C7CC4572C2E51355C53781B5641CC11DC54D8CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AftoTect.WPF.Pages;
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


namespace AftoTect.WPF.Pages {
    
    
    /// <summary>
    /// ExaminationPages
    /// </summary>
    public partial class ExaminationPages : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TicketLabel;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Timer;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel QuestionPanel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel QuestionsIndexPanel;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image questionImage;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionText;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ChoicesPanel;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\ExaminationPages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ExamResultPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AftoTect.WPF;component/pages/examinationpages.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ExaminationPages.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TicketLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Timer = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.QuestionPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.QuestionsIndexPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.questionImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.QuestionText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ChoicesPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.ExamResultPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            
            #line 50 "..\..\..\..\Pages\ExaminationPages.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

