using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using Microsoft.AspNetCore.Http.Features;
using System.Net.Http;
using FileUploadReceive.SampleApp.Utilities;

namespace FileUploadReceive
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly string _targetFolderPath = @"Files";

        public byte[] StreamedFileContent { get; private set; }

        [HttpPost("")]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> Upload()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                ModelState.AddModelError("File", "The request couldn't be processed (Error 1).");
                //_logger.LogWarning($"The request content type [{Request.ContentType}] is invalid.");
                return BadRequest(ModelState);
            }

            var formModel = new FormModel();

            var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType), new FormOptions().MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (contentDisposition.IsFileDisposition())
                    {
                        var trustedFileNameForDisplay = WebUtility.HtmlEncode(contentDisposition.FileName.Value);
                        string trustedFileNameForFileStorage;
                        trustedFileNameForFileStorage = trustedFileNameForDisplay;

                        //for better Validation use the following
                        //var streamedFileContent = await FileHelpers.ProcessStreamedFile(section, contentDisposition, ModelState, _permittedExtensions, _fileSizeLimit);

                        byte[] bytes;
                        using (var ms = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(ms);
                            bytes = ms.ToArray();
                        }

                        var streamedFileContent = bytes;

                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        var trustedFilePath = Path.Combine(_targetFolderPath, trustedFileNameForFileStorage);
                        using var targetStream = System.IO.File.Create(trustedFilePath);
                        await targetStream.WriteAsync(streamedFileContent);
                        FormModel.TrustedFilePath = trustedFilePath;
                        formModel.TrustedFileName = trustedFileNameForDisplay;
                        //_logger.LogInformation($"Uploaded file '{trustedFileNameForDisplay}' saved to '{_targetFolderPath}' as {trustedFileNameForFileStorage}");
                    }
                    else if (contentDisposition.IsFormDisposition())
                    {
                        var content = new StreamReader(section.Body).ReadToEnd();
                        if (contentDisposition.Name == "userId" && int.TryParse(content, out var useId))
                        {
                            FormModel.UserId = useId;
                        }

                        if (contentDisposition.Name == "comment")
                        {
                            formModel.Comment = content;
                        }

                        if (contentDisposition.Name == "isPrimary" && bool.TryParse(content, out var isPrimary))
                        {
                            FormModel.IsPrimary = isPrimary;
                        }
                    }
                }

                // Drain any remaining section body that hasn't been consumed and read the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            // todo: validate and persist formModel
            //_logger.LogInformation(formModel.ToString());
            //UploadController.Add(formModel);

            return Created("Upload", true);
        }

        private static void Add(FormModel formModel)
        {
            throw new NotImplementedException();
        }

        public class FormModel
        {
            internal static string TrustedFilePath;
            internal static int UserId;
            internal static bool IsPrimary;

            public string TrustedFileName { get; internal set; }
            public string Comment { get; internal set; }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var factories = context.ValueProviderFactories;
            factories.RemoveType<FormValueProviderFactory>();
            factories.RemoveType<FormFileValueProviderFactory>();
            factories.RemoveType<JQueryFormValueProviderFactory>();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
