﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocusignIntegration.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DocusignIntegration.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] SampleDoc {
            get {
                object obj = ResourceManager.GetObject("SampleDoc", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is a test .txt file uploaded by DocuSign QA department.
        ///
        ///Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam leo eros, feugiat at convallis dictum, sollicitudin eget nunc. In rhoncus fringilla nisi a consectetur. Fusce congue gravida risus quis porta. Etiam ut leo enim. Nunc molestie bibendum augue, ultrices bibendum felis rutrum et. In consectetur mi ac neque ultricies ac luctus velit interdum. Morbi et nunc est, at porttitor tortor. Nunc vel enim a arcu ultricies tempus. Proin egestas, orc [rest of string was truncated]&quot;;.
        /// </summary>
        public static string Small {
            get {
                return ResourceManager.GetString("Small", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is a test .txt file uploaded by DocuSign QA department..
        /// </summary>
        public static string Small2 {
            get {
                return ResourceManager.GetString("Small2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] smallPDF {
            get {
                object obj = ResourceManager.GetObject("smallPDF", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
