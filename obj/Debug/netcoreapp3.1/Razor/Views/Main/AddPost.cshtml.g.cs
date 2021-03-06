#pragma checksum "D:\Projects\TheTopPost\Views\Main\AddPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01f4aea74a6af31a78b09497b73686a1007d65d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_AddPost), @"mvc.1.0.view", @"/Views/Main/AddPost.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\TheTopPost\Views\_ViewImports.cshtml"
using TheTopPost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\TheTopPost\Views\_ViewImports.cshtml"
using TheTopPost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Projects\TheTopPost\Views\Main\AddPost.cshtml"
using PaulMiami.AspNetCore.Mvc.Recaptcha;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01f4aea74a6af31a78b09497b73686a1007d65d4", @"/Views/Main/AddPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a082e225ae2763576c2b5e84e1fb8c48809f1c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_AddPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sendForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Main", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SendPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaTagHelper __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper;
        private global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaScriptTagHelper __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h2 style=""margin-top:15px"">Add new Post</h2>
<div class=""posts"" style=""margin-top:10px"">
    <div class=""row"">        
        <input form=""sendForm"" name=""image"" type=""file"" id=""inputfile"" accept=""image/*"" style=""display:none"" onchange=""preview_image(event)"">
        <label for=""inputfile"" class=""button loadImage"">
            <span class=""textPost"">
                Choose image
            </span>
        </label>
    </div>
    <div class=""row"">
        <div class=""post"">
            <img form=""sendForm"" name=""image"" id=""output_image"" class=""pic"" src=""/images/DefaultImage.jpg"">
            <textarea form=""sendForm"" required name=""textPost"" class=""scroller newPost"" maxlength=""255"" placeholder=""Write your post here...""></textarea>
            <div class=""datePost"">
                ");
#nullable restore
#line 18 "D:\Projects\TheTopPost\Views\Main\AddPost.cshtml"
           Write(DateTime.Now.ToString("MM.dd.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""row"">
        <textarea form=""sendForm"" required name=""codePost"" class=""sendCode"" maxlength=""50"" placeholder=""Write your code here...""></textarea>
    </div>
    <div class=""row"" style=""margin:15px"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01f4aea74a6af31a78b09497b73686a1007d65d46609", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("recaptcha", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "01f4aea74a6af31a78b09497b73686a1007d65d46879", async() => {
                }
                );
                __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper = CreateTagHelper<global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaTagHelper>();
                __tagHelperExecutionContext.Add(__PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper);
#nullable restore
#line 27 "D:\Projects\TheTopPost\Views\Main\AddPost.cshtml"
__PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper.Size = RecaptchaSize.Normal;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("size", __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper.Size, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"row\">\r\n        <input form=\"sendForm\" id=\"confirm\" type=\"submit\" class=\"button sendButton\" style=\"visibility:hidden\" value=\"Send Post\">\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("recaptcha-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "01f4aea74a6af31a78b09497b73686a1007d65d410406", async() => {
                }
                );
                __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaScriptTagHelper = CreateTagHelper<global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaScriptTagHelper>();
                __tagHelperExecutionContext.Add(__PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaScriptTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>
        function preview_image(event) {
            var reader = new FileReader();

            reader.onload = function () {
                var output = document.getElementById('output_image');
                output.src = reader.result;
            }

            reader.readAsDataURL(event.target.files[0]);
        }

        function recaptchaValidated() {
            var buttonnoclick = document.getElementById(""confirm"");
            buttonnoclick.style.visibility = ""visible""
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
