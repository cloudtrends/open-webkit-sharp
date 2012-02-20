
#if DEBUG || RELEASE
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebKit.JSCore;
using System.Threading;
using WebKit.Interop;

namespace WebKit
{
    public class JSManagement
    {
        WebKitBrowser _owner;
        public JSManagement(WebKitBrowser browser)
        {
            _owner = browser;
            ScriptObject = new JSCore.JSContext(browser.WebView.mainFrame());
        }

        /// <summary>
        /// Returns the Global Context for JavaScript use.
        /// </summary>
        public JSCore.JSContext GlobalContext
        {
            get 
            {
                return new JSCore.JSContext(_owner.WebView.mainFrame());
            }
        }

        /// <summary>
        /// Calls a function with the specified arguments in the script environment.
        /// </summary>
        public JSValue CallFunction(string Name, object[] arguments)
        {
            JSCore.JSObject global = GlobalContext.GetGlobalObject();
            JSCore.JSValue window = global.GetProperty("window");
            if (window == null || !window.IsObject) 
                return null;
            JSCore.JSObject windowObj = window.ToObject();
            return windowObj.CallFunction(Name, arguments);
            //return GlobalContext.GetGlobalObject().CallFunction(Name, arguments);
        }

        /// <summary>
        /// Executes a Script in the Global Context and returns its value.
        /// </summary>
        public JSCore.JSValue EvaluateScript(string Name)
        {
            JSCore.JSValue val = ((JSCore.JSContext)GlobalContext).EvaluateScript(Name);
            return val != null ? val : null;
        }

        internal void CreateWindowScriptObject(JSCore.JSContext context)
        {
            if (ScriptObject != null && context != null)
            {
                JSCore.JSObject global = context.GetGlobalObject();
                JSCore.JSValue window = global.GetProperty("window");
                if (window == null || !window.IsObject) return;
                JSCore.JSObject windowObj = window.ToObject();
                if (windowObj == null) return;
                windowObj.SetProperty("external", (object)ScriptObject);
            }
        }

        /// <summary>
        /// Gets or sets the Script Object that can be accessed for JavaScript use.
        /// </summary>
        /// <value>The object that can be used for scripting.</value>
        public object ScriptObject
        {
            get { return so; }
            set
            {
                so = value;
                CreateWindowScriptObject(GlobalContext);
            }
        }

        internal object so { get; set; }
    }
}
#endif