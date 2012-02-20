/*
 * Copyright (c) 2009, Peter Nelson (charn.opcode@gmail.com)
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * * Redistributions of source code must retain the above copyright notice, 
 *   this list of conditions and the following disclaimer.
 * * Redistributions in binary form must reproduce the above copyright notice, 
 *   this list of conditions and the following disclaimer in the documentation 
 *   and/or other materials provided with the distribution.
 *   
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE 
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
 * POSSIBILITY OF SUCH DAMAGE.
*/

// More info at
// http://developer.apple.com/documentation/Cocoa/Reference/WebKit/Protocols/WebResourceLoadDelegate_Protocol

using System;
using System.Collections.Generic;
using System.Text;
using WebKit;
using WebKit.Interop;

namespace WebKit
{
    internal delegate void PluginFailedWithError(WebView sender, WebError error);
    internal delegate void ResourceStartedLoading(WebURLResponse res);
    internal delegate void ResourceFinishedLoading(WebURLResponse res);
    internal delegate void ResourceSizeAvailableEventHandler(WebURLResponse res, int length);
    internal delegate void ResourceFailed(WebURLResponse res, WebError error);
    internal delegate string ResourceRequest(string url);
    internal class WebResourceLoadDelegate : IWebResourceLoadDelegate
    {
        public event PluginFailedWithError PluginFailed = delegate { };
        public event ResourceFinishedLoading ResourceLoaded = delegate { };
        public event ResourceSizeAvailableEventHandler ResourceSizeAvailable = delegate { };
        public event ResourceStartedLoading ResourceLoading = delegate { };
        public event ResourceRequest ResourceRequestSent;
        public event ResourceFailed ResourceFailedLoading = delegate { };
        private Dictionary<uint, WebURLResponse> resources = new Dictionary<uint, WebURLResponse>();
        public void didCancelAuthenticationChallenge(WebView WebView, uint identifier, IWebURLAuthenticationChallenge challenge, IWebDataSource dataSource)
        {
        }

        public void didFailLoadingWithError(WebView WebView, uint identifier, WebError error, IWebDataSource dataSource)
        {
            WebURLResponse resp = null;
            resources.TryGetValue(identifier, out resp);
            if (resp != null)
            ResourceFailedLoading(resources[identifier], error);
        }

        public void didFinishLoadingFromDataSource(WebView WebView, uint identifier, IWebDataSource dataSource)
        {
            ResourceLoaded(resources[identifier]);
        }

        public void didReceiveAuthenticationChallenge(WebView WebView, uint identifier, IWebURLAuthenticationChallenge challenge, IWebDataSource dataSource)
        {
        }

        public void didReceiveContentLength(WebView WebView, uint identifier, uint length, IWebDataSource dataSource)
        {
            int received = (int)length;
            try
            {
                ResourceSizeAvailable(resources[identifier], received);
            }
            catch { }
        }

        public void didReceiveResponse(WebView WebView, uint identifier, WebURLResponse response, IWebDataSource dataSource)
        {
            ResourceLoading(response);
            resources.Add(identifier, response);
        }

        public void identifierForInitialRequest(WebView WebView, IWebURLRequest request, IWebDataSource dataSource, uint identifier)
        {
        }

        public void plugInFailedWithError(WebView WebView, WebError error, IWebDataSource dataSource)
        {
            PluginFailed(WebView, error);
        }

        public IWebURLRequest willSendRequest(WebView WebView, uint identifier, IWebURLRequest request, WebURLResponse redirectResponse, IWebDataSource dataSource)
        {
            string ret = ResourceRequestSent(request.url());
            if (string.IsNullOrEmpty(ret))
            {
                return null;
            }
            else
            {
                request.initWithURL(ret, _WebURLRequestCachePolicy.WebURLRequestUseProtocolCachePolicy, 60);
                return request;
            }
        }

        public void identifierForInitialRequest(WebView WebView, WebURLRequest request, IWebDataSource dataSource, uint identifier)
        {
        }

        public WebURLRequest willSendRequest(WebView WebView, uint identifier, WebURLRequest request, WebURLResponse redirectResponse, IWebDataSource dataSource)
        {
            return request; 
        }
    }
}
