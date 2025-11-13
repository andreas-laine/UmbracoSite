using Umbraco.Cms.Core.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Services;

public class FormSubmissionsService(IContentService contentService)
{

    private readonly IContentService _contentService = contentService;

    public bool SaveCallbackRequest(CallBackFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == "formSubmissions");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
